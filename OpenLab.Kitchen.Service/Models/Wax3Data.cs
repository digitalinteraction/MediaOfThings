using System;
using OpenLab.Kitchen.Service.Interfaces;

namespace OpenLab.Kitchen.Service.Models
{
    public class Wax3Data : TimeModel, IStreamingModel, IDataModel
    {
        public int DeviceId { get; set; }

        public float AccX { get; set; }

        public float AccY { get; set; }

        public float AccZ { get; set; }

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
