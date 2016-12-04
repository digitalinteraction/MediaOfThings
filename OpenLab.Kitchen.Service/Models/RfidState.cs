﻿using System;
using System.Collections.Generic;

namespace OpenLab.Kitchen.Service.Models
{
    public class RfidState : DataModel
    {
        public string DeviceId { get; set; }

        public ICollection<TransponderState> Transponders { get; set; }

        public override string IdString()
        {
            return DeviceId;
        }
    }

    public class TransponderState
    {
        public string Id { get; set; }

        public bool Active { get; set; }

        public DateTime LastSeen { get; set; }
    }
}
