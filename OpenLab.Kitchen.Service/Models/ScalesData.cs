using System;
using OpenLab.Kitchen.Service.Interfaces;

namespace OpenLab.Kitchen.Service.Models
{
    public class ScalesData : TimeModel, IStreamingModel, IDataModel
    {
        public int DeviceId { get; set; }

        public float Weight { get; set; }

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
