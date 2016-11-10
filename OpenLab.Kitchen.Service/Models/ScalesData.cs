using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenLab.Kitchen.Service.Models
{
    public class ScalesData : DataModel
    {
        public int DeviceId { get; set; }

        public float Weight { get; set; }

        public override string GetDeviceIdString()
        {
            return DeviceId.ToString();
        }
    }
}
