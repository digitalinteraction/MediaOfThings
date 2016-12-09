using System;
using System.Numerics;
using System.Linq;
using OpenLab.Kitchen.Service.Models;

namespace OpenLab.Kitchen.Recogniser.Library
{
    public class Wax3Recogniser : Recogniser<Wax3Data, Wax3State>
    {
        private const double AliveThreshold = 5000;

        public Wax3Recogniser() : base() {}

        public override void Update(Wax3Data data)
        {
            base.Update(data);

            var vector = new Vector3(data.AccX, data.AccY, data.AccZ);

            Wax3State oldState;
            States.TryGetValue(data.IdString(), out oldState);
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

                States.Add(data.IdString(), newState);
            }
            else
            {
                // Update Time Alive if considered to be continous
                var millisecondsSinceLast = (oldState.LastAlive - data.Timestamp).TotalMilliseconds;
                if (millisecondsSinceLast < AliveThreshold)
                {
                    newState.TimeAlive = oldState.TimeAlive + millisecondsSinceLast;
                }
                else
                {
                    newState.TimeAlive = 0;
                    newState.Noise = vector.Length();
                }

                newState.Noise = (oldState.Noise + vector.Length()) / 2f;

                States[data.IdString()] = newState;
            }

            OnStateChanged(this, newState);
        }

        public override void UpdateClock(DateTime newClock)
        {
            base.UpdateClock(newClock);

            foreach (var key in States.Keys.ToArray().Where(k => States[k].Active))
            {
                var millisecondsSinceLast = (Clock - States[key].LastAlive).TotalMilliseconds;
                if (millisecondsSinceLast > AliveThreshold)
                {
                    var newState = new Wax3State
                    {
                        Timestamp = States[key].LastAlive.AddMilliseconds(AliveThreshold),
                        DeviceId = States[key].DeviceId,
                        Active = false,
                        LastAlive = States[key].LastAlive.AddMilliseconds(AliveThreshold),
                        TimeAlive = States[key].TimeAlive + AliveThreshold,
                    };

                    States[key] = newState;
                    OnStateChanged(this, newState);
                }
            }
        }
    }
}
