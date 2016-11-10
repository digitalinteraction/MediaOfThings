using System;
using System.Collections.Generic;
using System.Text;

namespace OpenLab.Kitchen.Service.Models
{
    public class Wax3Event : DataModel
    {
        public int DeviceId { get; set; }

        public Wax3EventType EventType { get; set; }

        public enum Wax3EventType
        {
            Active,
            InActive
        }

        public override string GetDeviceIdString()
        {
            return DeviceId.ToString();
        }
    }
}
