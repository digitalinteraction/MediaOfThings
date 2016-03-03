using System.Collections.Generic;
using System.Linq;

namespace OpenLab.Kitchen.Service.Models
{
    public class Rfid : Model
    {
        public int DeviceId { get; set; }

        public IEnumerable<RfidData> TransponderData { get; set; }
    }
}
