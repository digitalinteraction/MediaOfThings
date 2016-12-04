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
        public struct Significance
        {
            public const double Rfid = 0.2;
            public const double Wax3 = 0.001;
            public const double Appliance = 1;
            public const double Timeout = 0.01;
        }

        private DateTime Clock { get; set; }
        private IDictionary<Guid, AoiState> _aoiStates;
        private Production _production;
        private IDictionary<string, IEnumerable<TransponderState>> _padStates;

        public event StateChangedEventHandler<AoiState> StateChanged;

        public AoiClassifier(DateTime startTime, Production production)
        {
            Clock = startTime;

            _production = production;
            _aoiStates = production.AreaConfig.ToDictionary(a => a.Id, a => new AoiState { AreaId = a.Id, Value =  0.0 });
            _padStates = new Dictionary<string, IEnumerable<TransponderState>>();
        }

        public void Update(Wax3State data)
        {
            if (!data.Active) return;

            foreach (var area in _aoiStates.Keys)
            {
                var oldState = _aoiStates[area];
                var newState = new AoiState
                {
                    AreaId = area,
                    Value = oldState.Value += Significance.Wax3
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
                var newState = new AoiState { AreaId = area.Id };
                newState.Value = oldState.Value + Significance.Rfid;

                _aoiStates[area.Id] = newState;
                StateChanged(this, newState);
            }
        }

        public void Update(ApplianceEvent data)
        {
            var at = _production.SmappeeConfig[data.ApplianceId]; //.AssociatedTransponder;
            /*if (!string.IsNullOrEmpty(at))
            {
                var pad = _padStates.SingleOrDefault(p => p.Value.Any(t => t.Id == at)).Key;
                if (!string.IsNullOrEmpty(pad))
                {
                    var areas = GetAssociatedAreas(pad);

                    foreach (var area in areas)
                    {
                        var oldState = _aoiStates[area.Id];
                        var newState = new AoiState { AreaId = area.Id };

                        if (data.WattChange > 0)
                        {
                            newState.Value = oldState.Value + Significance.Appliance;
                        }
                        else
                        {
                            newState.Value = oldState.Value - Significance.Appliance;
                            if (newState.Value < 0) newState.Value = 0;
                        }

                        _aoiStates[area.Id] = newState;
                        StateChanged(this, newState);
                    }
                }
            }*/
        }

        public void UpdateClock(DateTime newClock)
        {
            Clock = newClock;

            foreach (var area in _aoiStates.Keys)
            {
                var oldState = _aoiStates[area];
                var newState = new AoiState { AreaId = area };

                newState.Value = oldState.Value -= Significance.Timeout;
                _aoiStates[area] = newState;
                StateChanged(this, newState);
            }
        }

        private IEnumerable<Area> GetAssociatedAreas(string padId)
        {
            return _production.AreaConfig.Where(a => a.RfidPads.Contains(padId) || a.PresentationPads.Contains(padId));
        }
    }
}