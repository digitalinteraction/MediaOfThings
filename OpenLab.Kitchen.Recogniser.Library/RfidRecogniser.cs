﻿using System;
using System.Linq;
using System.Collections.Generic;
using OpenLab.Kitchen.Service.Models;

namespace OpenLab.Kitchen.Recogniser.Library
{
    public class RfidRecogniser : Recogniser<RfidData, RfidState>
    {
        private const double TransponderTimeout = 5000;

        public override void Update(RfidData data)
        {
            base.Update(data);

            RfidState oldState;
            States.TryGetValue(data.IdString(), out oldState);
            var newState = new RfidState
            {
                Timestamp = data.Timestamp,
                DeviceId = data.DeviceId
            };

            if (oldState == null)
            {
                newState.Transponders = new List<TransponderState>();

                foreach (var transponder in data.Transponders)
                {
                    newState.Transponders.Add(new TransponderState
                    {
                        Id = transponder,
                        LastSeen = data.Timestamp,
                        Active = true
                    });
                }

                States.Add(data.IdString(), newState);
            }
            else
            {
                newState.Transponders = oldState.Transponders;

                // Add all new transponders and update last seen for old ones
                foreach (var transponder in data.Transponders)
                {
                    var transponderState = newState.Transponders.SingleOrDefault(t => t.Id == transponder);

                    if (transponderState == default(TransponderState))
                    {
                        newState.Transponders.Add(new TransponderState
                        {
                            Id = transponder,
                            LastSeen = data.Timestamp,
                            Active = true
                        });
                    }
                    else
                    {
                        transponderState.LastSeen = data.Timestamp;
                        transponderState.Active = true;
                    }
                }

                States[data.IdString()] = newState;
            }
            OnStateChanged(this, newState);
        }

        public override void UpdateClock(DateTime newClock)
        {
            base.UpdateClock(newClock);

            foreach (var key in States.Keys.ToArray())
            {
                var changed = false;
                DateTime lastestUpdate = new DateTime();

                var newState = new RfidState
                {
                    DeviceId = States[key].DeviceId,
                    Transponders = States[key].Transponders
                };

                // Remove expired Transponders
                foreach (var transponder in newState.Transponders.Where(t => t.Active))
                {
                    var millisecondsSinceLast = (Clock - transponder.LastSeen).TotalMilliseconds;
                    if (millisecondsSinceLast > TransponderTimeout)
                    {
                        transponder.Active = false;
                        changed = true;

                        var timeoutTime = transponder.LastSeen.AddMilliseconds(TransponderTimeout);
                        if (lastestUpdate < timeoutTime)
                        {
                            lastestUpdate = timeoutTime;
                        }
                    }
                }

                if (changed)
                {
                    newState.Timestamp = lastestUpdate;
                    States[key] = newState;
                    OnStateChanged(this, newState);
                }
            }
        }
    }
}
