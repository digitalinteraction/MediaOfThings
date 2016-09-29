using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenLab.Kitchen.Service.Models.Streaming
{
    public class WaterFlow : StreamingModel
    {
        public float WaterUsed { get; set; }

        public DateTime Time { get; set; }
    }
}
