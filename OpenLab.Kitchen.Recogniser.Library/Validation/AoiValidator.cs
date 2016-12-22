using System;
using System.Collections.Generic;
using System.Linq;
using OpenLab.Kitchen.Service.Models;

namespace OpenLab.Kitchen.Recogniser.Library.Validation
{
    public class AoiValidator
    {
        private const double MatchThreshold = 1;
        private const double GTTimeout = 5000;

        private readonly Production _production;
        private readonly IQueryable<AoiState> _aois;
        private readonly IQueryable<GTLocation> _groundTruth;

        public AoiValidator(Production production, IQueryable<AoiState> aois, IQueryable<GTLocation> groundTruth)
        {
            _production = production;
            _aois = aois.OrderBy(a => a.Timestamp);
            _groundTruth = groundTruth.OrderBy(gt => gt.Timestamp);
        }

        public IDictionary<Guid, ValidationResult> ValidateAllAreas(double confidenceThreshold)
        {
            return _production.AreaConfig.ToDictionary(a => a.Id, a => ValidateArea(a.Id, confidenceThreshold));
        }

        public ValidationResult ValidateArea(Guid area, double confidenceThreshold)
        {
            var timings = new double[4];

            var lastTime = _groundTruth.First().Timestamp;
            var aois = _aois.Where(a => a.AreaId == area).ToArray();
            var index = 0;

            foreach (var gt in _groundTruth)
            {
                while (index < aois.Length && aois[index].Timestamp < gt.Timestamp)
                {
                    index++;
                }

                if (index >= aois.Length) break;

                var currentState = aois[index];
                var gtArea = GetAssociatedArea(gt);

                var aoiStatus = currentState != default(AoiState) && currentState.Value >= confidenceThreshold;
                var gtStatus = gtArea.Id == area;

                var period = gt.Timestamp - lastTime;
                if (period.TotalMilliseconds > GTTimeout)
                {
                    period = TimeSpan.Zero;
                }

                if (aoiStatus == gtStatus && aoiStatus) // True Positive
                {
                    timings[0] += period.TotalMilliseconds;
                }
                else if (aoiStatus != gtStatus && aoiStatus) // False Positive
                {
                    timings[1] += period.TotalMilliseconds;
                }
                else if (aoiStatus == gtStatus && !aoiStatus) // True Negative
                {
                    timings[2] += period.TotalMilliseconds;
                }
                else if (aoiStatus != gtStatus && !aoiStatus) // False Negative
                {
                    timings[3] += period.TotalMilliseconds;
                }
            }

            var totalTime = timings[0] + timings[1] + timings[2] + timings[3];

            return new ValidationResult
            {
                TruePositive = timings[0] / totalTime,
                TrueNegative = timings[1] / totalTime,
                FalsePositive = timings[2] / totalTime,
                FalseNegative = timings[3] / totalTime
            };
        }

        public GroupValidationResult ValidateGroups(double confidenceThreshold)
        {
            var areas = _production.AreaConfig.ToArray();
            var matrix = InitialiseCM(areas.Length, 0);
            var aoiState = areas.ToDictionary(a => a.Id, a => new AoiState { Value = 0});

            var aois = _aois.ToArray();
            var index = 0;

            var lastTime = _groundTruth.First().Timestamp;

            var unknownTime = 0.0;
            var totalTime = 0.0;

            foreach (var gt in _groundTruth)
            {
                var period = gt.Timestamp - lastTime;
                if (period.TotalMilliseconds > GTTimeout)
                {
                    period = TimeSpan.Zero;
                }

                totalTime += period.TotalMilliseconds;

                while (index < aois.Length && aois[index].Timestamp < gt.Timestamp)
                {
                    var current = aois[index];
                    aoiState[current.AreaId] = current;
                    index++;
                }

                if (index >= aois.Length) break;

                var maxAoi = aoiState.Values.OrderByDescending(a => a.Value).FirstOrDefault();

                if (maxAoi == default(AoiState)) continue;

                if (maxAoi.Value < confidenceThreshold)
                {
                    unknownTime += period.TotalMilliseconds;
                    continue;
                }

                var gtArea = GetAssociatedArea(gt);

                var aoiIndex = Array.FindIndex(areas, a => a.Id == maxAoi.AreaId);
                var gtIndex = Array.FindIndex(areas, a => a.Id == gtArea.Id);

                matrix[aoiIndex, gtIndex] += period.TotalMilliseconds;
            }

            matrix = ConvertCMToRatios(matrix, totalTime);

            return new GroupValidationResult { CM = matrix, Unknown = unknownTime / totalTime };
        }

        private Area GetAssociatedArea(GTLocation groundTruth)
        {
            return _production.AreaConfig.Single(a => a.GTRegionStart <= groundTruth.Estimated && a.GTRegionStop > groundTruth.Estimated);
        }

        private double[,] InitialiseCM(int size, double value)
        {
            var matrix = new double[size, size];

            for (var i = 0; i < size; i++)
            {
                for (var j = 0; j < size; j++)
                {
                    matrix[i,j] = value;
                }
            }

            return matrix;
        }

        private double[,] ConvertCMToRatios(double[,] matrix, double totalTime)
        {
            for (var i = 0; i < matrix.GetLength(0); i++)
            {
                for (var j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i,j] /= totalTime;
                }
            }

            return matrix;
        }
    }
}
