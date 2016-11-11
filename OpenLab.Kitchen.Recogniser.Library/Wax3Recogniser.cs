using System;
using System.Numerics;
using OpenLab.Kitchen.Service.Models;
using System.Linq;

namespace OpenLab.Kitchen.Recogniser.Library
{
    public class Wax3Recogniser : Recogniser<Wax3Data, Wax3State>
    {
        private const double ALIVETHRESHOLD = 5000;

        public Wax3Recogniser(DateTime startTime) : base(startTime) {}

        public override void Update(Wax3Data data)
        {
            base.Update(data);

            var vector = new Vector3(data.AccX, data.AccY, data.AccZ);

            Wax3State oldState;
            States.TryGetValue(data.DeviceIdString(), out oldState);
            var newState = new Wax3State
            {
                Timestamp = data.Timestamp,
                DeviceId = data.DeviceId,
                Active = true,
                LastAlive = data.Timestamp
            };

            if (oldState == null)
            {
                newState.TimeAlive = 0;
                newState.Noise = vector.Length();

                States.Add(data.DeviceIdString(), newState);
            }
            else
            {
                // Update Time Alive if considered to be continous
                var millisecondsSinceLast = (oldState.LastAlive - data.Timestamp).TotalMilliseconds;
                if (millisecondsSinceLast < ALIVETHRESHOLD)
                {
                    newState.TimeAlive = oldState.TimeAlive + millisecondsSinceLast;
                }
                else
                {
                    newState.TimeAlive = 0;
                    newState.Noise = vector.Length();
                }

                newState.Noise = (oldState.Noise + vector.Length()) / 2f;

                States[data.DeviceIdString()] = newState;
            }

            OnStateChanged(this, newState);
        }

        public override void UpdateClock(DateTime newClock)
        {
            base.UpdateClock(newClock);

            foreach (var key in States.Keys.ToArray().Where(k => States[k].Active))
            {
                var millisecondsSinceLast = (Clock - States[key].LastAlive).TotalMilliseconds;
                if (millisecondsSinceLast > ALIVETHRESHOLD)
                {
                    var newState = new Wax3State
                    {
                        Timestamp = States[key].LastAlive.AddMilliseconds(ALIVETHRESHOLD),
                        DeviceId = States[key].DeviceId,
                        Active = false,
                        LastAlive = States[key].LastAlive.AddMilliseconds(ALIVETHRESHOLD),
                        TimeAlive = States[key].TimeAlive + ALIVETHRESHOLD,
                    };

                    States[key] = newState;
                    OnStateChanged(this, newState);
                }
            }
        }
    }
}
