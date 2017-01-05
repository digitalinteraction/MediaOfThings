using System;
using OpenLab.Kitchen.Service.Interfaces;

namespace OpenLab.Kitchen.Service.Models
{
    public class Wax3State : TimeModel, IStreamingModel, IDataModel
    {
        public int DeviceId { get; set; }

        public bool Active { get; set; }

        public DateTime LastAlive { get; set; }

        public double TimeAlive { get; set; }

        public float Noise { get; set; }

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
