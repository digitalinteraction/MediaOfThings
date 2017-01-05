using System;
using System.Collections.Generic;
using System.Linq;
using OpenLab.Kitchen.Recogniser.Library.Interfaces;
using OpenLab.Kitchen.Recogniser.Library.Values;
using OpenLab.Kitchen.Service.Models;

namespace OpenLab.Kitchen.Recogniser.Library
{
    public class AoiClassifier : IRecogniser<Wax3State, AoiState>, IRecogniser<RfidState, AoiState>, IRecogniser<ApplianceEvent, AoiState>
    {
        private const double MaxConfidence = 2.0;
        private const double PresentationTimeout = 2000;
        private const double InteractionTimeout = 2000;

        public struct Significance
        {
            public const double Rfid = 0.2;
            public const double PresentationRfid = 1;
            public const double Wax3 = 0.001;
            public const double ApplianceStart = 1;
            public const double ApplianceStop = -1;
            public const double Decay = -0.01;
        }

        private DateTime Clock { get; set; }
        private IDictionary<Guid, AoiState> _aoiStates;
        private Production _production;
        private IDictionary<string, IEnumerable<TransponderState>> _padStates;

        public event StateChangedEventHandler<AoiState> StateChanged;

        public AoiClassifier(Production production)
        {
            _production = production;
            _aoiStates = production.AreaConfig.ToDictionary(a => a.Id, a => new AoiState { AreaId = a.Id, Value =  0.0 });
            _padStates = new Dictionary<string, IEnumerable<TransponderState>>();
        }

        public void Update(Wax3State data)
        {
            if (!data.Active) return;

            foreach (var area in _aoiStates.Keys.ToArray())
            {
                var oldState = _aoiStates[area];
                var newState = new AoiState
                {
                    Timestamp = data.Timestamp,
                    AreaId = area,
                    Value = UpdateConfidence(oldState.Value, Significance.Wax3),
                    Presentation = oldState.Presentation,
                    PresentationStarted = oldState.PresentationStarted
                };

                _aoiStates[area] = newState;
                StateChanged(this, newState);
            }
        }

        public void Update(RfidState data)
        {
            _padStates[data.DeviceId] = data.Transponders;

            if (!data.Transponders.Any(t => t.Active)) return;

            var areas = GetAssociatedAreas(data.DeviceId);

            foreach (var area in areas)
            {
                var oldState = _aoiStates[area.Id];
                var newState = new AoiState
                {
                    Timestamp = data.Timestamp,
                    AreaId = area.Id,
                    Interaction = oldState.Interaction,
                    InteractionStarted = oldState.InteractionStarted,
                    Presentation = oldState.Presentation,
                    PresentationStarted = oldState.PresentationStarted
                };
                newState.Value = UpdateConfidence(oldState.Value, Significance.Rfid);

                if (area.PresentationPads.Contains(data.DeviceId))
                {
                    newState.Presentation = true;
                    newState.PresentationStarted = data.Timestamp;
                }

                _aoiStates[area.Id] = newState;
                StateChanged(this, newState);
            }
        }

        public void Update(ApplianceEvent data)
        {
            var app = _production.SmappeeConfig.SingleOrDefault(a => a.Id == data.ApplianceId);

            if (app == default(Appliance) || string.IsNullOrEmpty(app.AssociatedTransponder)) return;

            var pad = _padStates.SingleOrDefault(p => p.Value.Any(t => t.Id == app.AssociatedTransponder && t.Active)).Key;
            if (!string.IsNullOrEmpty(pad))
            {
                var areas = GetAssociatedAreas(pad);

                foreach (var area in areas)
                {
                    var oldState = _aoiStates[area.Id];
                    var newState = new AoiState
                    {
                        Timestamp = data.Timestamp,
                        AreaId = area.Id
                    };

                    if (data.WattChange > 0)
                    {
                        newState.Value = UpdateConfidence(oldState.Value, Significance.ApplianceStart);
                    }
                    else
                    {
                        newState.Value = UpdateConfidence(oldState.Value, Significance.ApplianceStop);
                        if (newState.Value < 0) newState.Value = 0;
                    }

                    _aoiStates[area.Id] = newState;
                    StateChanged(this, newState);
                }
            }
        }

        public void UpdateClock(DateTime newClock)
        {
            var lastClock = Clock != default(DateTime) ? Clock : newClock;
            Clock = newClock;

            foreach (var area in _aoiStates.Keys.ToArray())
            {
                var oldState = _aoiStates[area];
                var newState = new AoiState
                {
                    Timestamp = Clock,
                    AreaId = area,
                    Presentation = oldState.Presentation,
                    PresentationStarted = oldState.PresentationStarted
                };

                newState.Value = UpdateConfidence(oldState.Value, Significance.Decay * (Clock - lastClock).TotalSeconds);

                if (newState.Presentation)
                {
                    if ((newState.PresentationStarted - Clock).TotalMilliseconds > PresentationTimeout)
                    {
                        newState.Presentation = false;
                    }
                }

                if (newState.Interaction)
                {
                    if ((newState.InteractionStarted - Clock).TotalMilliseconds > InteractionTimeout)
                    {
                        newState.Interaction = false;
                    }
                }

                _aoiStates[area] = newState;
                StateChanged(this, newState);
            }
        }

        private double UpdateConfidence(double current, double increment)
        {
            var newValue = current + increment;
            return newValue < 0 ? 0.0 : newValue > MaxConfidence ? MaxConfidence : newValue;
        }

        private IEnumerable<Area> GetAssociatedAreas(string padId)
        {
            return _production.AreaConfig.Where(a => a.RfidPads.Contains(padId) || a.PresentationPads.Contains(padId));
        }
    }
}