using System;
using OpenLab.Kitchen.Service.Interfaces;

namespace OpenLab.Kitchen.Service.Models
{
    public class RfidData : TimeModel, IStreamingModel, IDataModel
    {
        public string DeviceId { get; set; }

        public string[] Transponders { get; set; }

        public string IdString()
        {
            return DeviceId;
        }

        public string RoutingKey()
        {
            return IdString();
        }
    }
}