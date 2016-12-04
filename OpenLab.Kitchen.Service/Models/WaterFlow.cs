using System;

namespace OpenLab.Kitchen.Service.Models
{
    public class WaterFlow : DataModel
    {
        public int DeviceId { get; set; }

        public float WaterUsed { get; set; }

        public DateTime Time { get; set; }

        public override string IdString()
        {
            return DeviceId.ToString();
        }
    }
}
