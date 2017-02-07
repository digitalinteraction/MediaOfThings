using System;
using OpenLab.Kitchen.Service.Interfaces;
using OpenLab.Kitchen.Service.Values;

namespace OpenLab.Kitchen.Service.Models
{
    public class Wax3Data : TimeModel, IStreamingModel, IDataModel
    {
        public int DeviceId { get; set; }

        public float AccX { get; set; }

        public float AccY { get; set; }

        public float AccZ { get; set; }

        public Vector3 NormalisedAccVector()
        {
            return new Vector3
            {
                X = AccX / 256.0,
                Y = AccY / 256.0,
                Z = AccZ / 256.0
            };
        }

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
