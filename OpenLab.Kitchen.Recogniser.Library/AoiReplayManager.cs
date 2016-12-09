using System;
using System.Linq;
using System.Collections.Generic;
using OpenLab.Kitchen.Recogniser.Library.Interfaces;
using OpenLab.Kitchen.Service.Models;

namespace OpenLab.Kitchen.Recogniser.Library
{
    public class AoiReplayManager : IReplayManager<AoiState>
    {
        private readonly AoiClassifier _classifier;
        private readonly IEnumerable<Wax3State> _wax3StateDataset;
        private readonly IEnumerable<RfidState> _rfidStateDataset;
        private readonly IEnumerable<ApplianceEvent> _appEventDataset;

        public ICollection<AoiState> States { get; }

        public AoiReplayManager(AoiClassifier classifier, IEnumerable<Wax3State> wax3StateDataset, IEnumerable<RfidState> rfidStateDataset, IEnumerable<ApplianceEvent> appEventDataset)
        {
            _classifier = classifier;

            _wax3StateDataset = wax3StateDataset.OrderBy(w => w.Timestamp);
            _rfidStateDataset = rfidStateDataset.OrderBy(w => w.Timestamp);
            _appEventDataset = appEventDataset.OrderBy(w => w.Timestamp);

            States = new List<AoiState>();
        }

        public void Process()
        {
            _classifier.StateChanged += (sender, state) =>
            {
                States.Add(state);
            };

            var wax3Data = new Queue<Wax3State>(_wax3StateDataset);
            var rfidData = new Queue<RfidState>(_rfidStateDataset);
            var appData = new Queue<ApplianceEvent>(_appEventDataset);

            while (wax3Data.Any() || rfidData.Any() || appData.Any())
            {
                var min = new DateTime(
                    Math.Min(wax3Data.Any() ? wax3Data.Peek().Timestamp.Ticks : long.MaxValue,
                    Math.Min(rfidData.Any() ? rfidData.Peek().Timestamp.Ticks : long.MaxValue,
                             appData.Any()  ? appData.Peek().Timestamp.Ticks  : long.MaxValue))
                );

                _classifier.UpdateClock(min);

                if (wax3Data.Any() && wax3Data.Peek().Timestamp == min)
                {
                    _classifier.Update(wax3Data.Dequeue());
                }

                if (rfidData.Any() && rfidData.Peek().Timestamp == min)
                {
                    _classifier.Update(rfidData.Dequeue());
                }

                if (appData.Any() && appData.Peek().Timestamp == min)
                {
                    _classifier.Update(appData.Dequeue());
                }
            }
        }

        public IEnumerable<AoiState> GetStates()
        {
            return States;
        }
    }
}
