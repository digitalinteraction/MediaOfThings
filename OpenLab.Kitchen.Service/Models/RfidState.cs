using System;
using System.Collections.Generic;
using OpenLab.Kitchen.Service.Interfaces;

namespace OpenLab.Kitchen.Service.Models
{
    public class RfidState : TimeModel, IStreamingModel, IDataModel
    {
        public string DeviceId { get; set; }

        public ICollection<TransponderState> Transponders { get; set; }

        public string IdString()
        {
            return DeviceId;
        }

        public string RoutingKey()
        {
            return IdString();
        }
    }

    public class TransponderState
    {
        public string Id { get; set; }

        public bool Active { get; set; }

        public DateTime LastSeen { get; set; }
    }
}
