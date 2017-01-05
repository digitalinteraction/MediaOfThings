using System;
using OpenLab.Kitchen.Service.Interfaces;

namespace OpenLab.Kitchen.Service.Models
{
    public class WaterFlow : TimeModel, IStreamingModel, IDataModel
    {
        public int DeviceId { get; set; }

        public float WaterUsed { get; set; }

        public DateTime Time { get; set; }

        public string IdString()
        {
            return DeviceId.ToString();
        }

        public string RoutingKey()
        {
            return IdString();
        }
    }
}
