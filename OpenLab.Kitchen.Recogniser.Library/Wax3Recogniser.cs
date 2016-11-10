using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;
using OpenLab.Kitchen.Service.Models;
using OpenLab.Kitchen.Recogniser.Library.AnalysisModels;

namespace OpenLab.Kitchen.Recogniser.Library
{
    public class Wax3Recogniser : Recogniser<Wax3Data, int, Wax3State>
    {
        private const double ALIVETHRESHOLD = 5000;

        public override Wax3State Update(Wax3Data data)
        {
            var vector = new Vector3(data.AccX, data.AccY, data.AccZ);

            if (!States.ContainsKey(data.DeviceId))
            {
                States.Add(data.DeviceId, new Wax3State
                {
                    LastAlive = data.Timestamp,
                    TimeAlive = 0,
                    Noise = vector.Length()
                });
            }

            var state = States[data.DeviceId];

            // Update Time Alive if considered to be continous
            var millisecondsSinceLast = (state.LastAlive - data.Timestamp).TotalMilliseconds;
            if (millisecondsSinceLast < ALIVETHRESHOLD)
            {
                state.TimeAlive += millisecondsSinceLast;
            }
            else
            {
                state.TimeAlive = 0;
                state.Noise = vector.Length();
            }

            state.LastAlive = data.Timestamp;

            state.Noise = (state.Noise + vector.Length()) / 2f;

            return state;
        }
    }
}
