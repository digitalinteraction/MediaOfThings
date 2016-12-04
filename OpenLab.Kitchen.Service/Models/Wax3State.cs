using System;

namespace OpenLab.Kitchen.Service.Models
{
    public class Wax3State : DataModel
    {
        public int DeviceId { get; set; }

        public bool Active { get; set; }

        public DateTime LastAlive { get; set; }

        public double TimeAlive { get; set; }

        public float Noise { get; set; }

        public override string IdString()
        {
            return DeviceId.ToString();
        }
    }
}
