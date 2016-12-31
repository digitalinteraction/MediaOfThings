using System;
using System.Linq;
using System.Collections.Generic;
using OpenLab.Kitchen.Service.Models;

namespace OpenLab.Kitchen.Recogniser.Library
{
    public class AutoDirector : Recogniser<AoiState, ShotDecision>
    {
        private const double NewShotThreshold = 5000;
        private const double SafeShotTimeout = 10000;

        private readonly Production _production;
        private readonly IDictionary<Guid, AoiState> _aoiStates;
        private readonly IDictionary<Guid, ShotDecision> _cameras;

        public AutoDirector(Production production)
        {
            _production = production;
            _aoiStates = production.AreaConfig.ToDictionary(a => a.Id, a => new AoiState { AreaId = a.Id, Value = 0.0 });
            _cameras = production.Cameras.ToDictionary(c => c.Id, c => new ShotDecision { Timestamp = DateTime.MinValue, Frame = c.SafeShot });
        }

        public override void Update(AoiState aoi)
        {
            base.Update(aoi);

            foreach (var c in _cameras.Keys.ToArray())
            {
                var cameraConfig = _production.Cameras.Single(cam => cam.Id == c);
                var oldShot = _cameras[c];
                var newShot = new ShotDecision {Timestamp = Clock, CameraId = c};

                if ((oldShot.Timestamp - Clock).Milliseconds < NewShotThreshold)
                {
                    if (aoi.Presentation)
                    {
                        newShot.Frame = cameraConfig.DetailShots[aoi.AreaId];
                    }
                    else if (aoi.Interaction)
                    {
                        newShot.Frame = cameraConfig.DetailShots[aoi.AreaId];
                    }
                    else
                    {
                        newShot.Frame = cameraConfig.FaceUpShots[aoi.AreaId];
                    }

                    OnStateChanged(this, newShot);
                }
            }
        }

        public override void UpdateClock(DateTime clock)
        {
            base.UpdateClock(clock);

            foreach (var c in _cameras.Keys.ToArray())
            {
                var cameraConfig = _production.Cameras.Single(cam => cam.Id == c);
                var oldShot = _cameras[c];
                var newShot = new ShotDecision {Timestamp = Clock, CameraId = c};

                if ((oldShot.Timestamp - Clock).Milliseconds < SafeShotTimeout)
                {
                    newShot.Frame = cameraConfig.SafeShot;

                    OnStateChanged(this, newShot);
                }
            }
        }
    }
}
