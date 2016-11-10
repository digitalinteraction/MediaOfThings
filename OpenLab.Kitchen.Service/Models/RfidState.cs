using System;
using System.Collections.Generic;
using System.Text;

namespace OpenLab.Kitchen.Service.Models
{
    public class RfidState : DataModel
    {
        public string DeviceId { get; set; }

        public string[] Transponders { get; set; }

        public override string GetDeviceIdString()
        {
            return DeviceId;
        }
    }
}
