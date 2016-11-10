using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenLab.Kitchen.Service.Models
{
    public class Wax3Data : DataModel
    {
        public int DeviceId { get; set; }

        public float AccX { get; set; }

        public float AccY { get; set; }

        public float AccZ { get; set; }

        public override string GetDeviceIdString()
        {
            return DeviceId.ToString();
        }
    }
}
