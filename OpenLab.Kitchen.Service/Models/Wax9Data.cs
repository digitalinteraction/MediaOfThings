using OpenLab.Kitchen.Service.Interfaces;

namespace OpenLab.Kitchen.Service.Models
{
    public class Wax9Data : TimeModel, IStreamingModel, IDataModel
    {
        public string DeviceId { get; set; }

        public int SampleNumber { get; set; }

        public float AccX { get; set; }

        public float AccY { get; set; }

        public float AccZ { get; set; }

        public float GyroX { get; set; }

        public float GyroY { get; set; }

        public float GyroZ { get; set; }

        public float MagX { get; set; }

        public float MagY { get; set; }

        public float MagZ { get; set; }

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