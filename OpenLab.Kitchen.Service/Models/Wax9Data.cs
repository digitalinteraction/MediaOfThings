using System;

namespace OpenLab.Kitchen.Service.Models
{
    public class Wax9Data : Model
    {
        public DateTime DataTimeStamp { get; set; }

        float AccX { get; set; }

        float AccY { get; set; }

        float AccZ { get; set; }

        float GyroX { get; set; }

        float GyroY { get; set; }

        float GyroZ { get; set; }

        float MagX { get; set; }

        float MagY { get; set; }

        float MagZ { get; set; }
    }
}
