using System;
using System.Collections.Generic;
using System.Text;
using OpenLab.Kitchen.Service.Models;
using OpenLab.Kitchen.Recogniser.Library.AnalysisModels;

namespace OpenLab.Kitchen.Recogniser.Library
{
    public class RfidRecogniser : Recogniser<RfidData, string, RfidState>
    {
        private const double TRANSPONDERTIMEOUT = 5000;

        public override RfidState Update(RfidData data)
        {
            if (!States.ContainsKey(data.DeviceId))
            {
                var newState = new RfidState();

                foreach (var transponder in data.Transponders)
                {
                    newState.Transponders.Add(transponder, data.Timestamp);
                }

                States.Add(data.DeviceId, newState);
            }

            var state = States[data.DeviceId];

            // Add all new transponders and update last seen for old ones
            foreach (var transponder in data.Transponders)
            {
                if (!state.Transponders.ContainsKey(transponder))
                {
                    state.Transponders.Add(transponder, data.Timestamp);
                }
                else
                {
                    state.Transponders[transponder] = data.Timestamp;
                }
            }

            // Remove expired Transponders
            foreach (var transponder in state.Transponders)
            {
                var millisecondsSinceLast = (transponder.Value - data.Timestamp).TotalMilliseconds;
                if (millisecondsSinceLast > TRANSPONDERTIMEOUT)
                {
                    state.Transponders.Remove(transponder.Key);
                }
            }

            return state;
        }
    }
}
