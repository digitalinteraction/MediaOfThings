using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenLab.Kitchen.Service.Models.Streaming
{
    public abstract class StreamingModel
    {
        public int LocationId { get; set; }

        public string DeviceId { get; set; }

        public DateTime DataTimeStamp { get; set; }
    }
}
