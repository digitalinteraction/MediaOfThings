using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenLab.Kitchen.Service.Models
{
    public class WaterFlow : DataModel
    {
        public int DeviceId { get; set; }

        public float WaterUsed { get; set; }

        public DateTime Time { get; set; }

        public override string DeviceIdString()
        {
            return DeviceId.ToString();
        }
    }
}
