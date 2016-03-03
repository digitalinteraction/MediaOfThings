using System;

namespace OpenLab.Kitchen.Service.Models
{
    public class Wax3Data : Model
    {
        public DateTime DataTimeStamp { get; set; }

        public float BatteryLevel { get; set; }

        public float AccX { get; set; }

        public float AccY { get; set; }

        public float AccZ { get; set; }
    }
}