using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenLab.Kitchen.Service.Values;

namespace OpenLab.Kitchen.Service.Models
{
    public class Production : Model
    {
        public string Name { get; set; }

        public IEnumerable<Take> Takes { get; set; }

        public Dictionary<string,string> RfidConfig { get; set; }

        public Dictionary<int, string> SmappeeConfig { get; set; }

        public Dictionary<int, string> Wax3Config { get; set; }

        public IEnumerable<Area> AreaConfig { get; set; }
    }

    public class Take
    {
        public string Name { get; set; }

        public IEnumerable<Media> Media { get; set; }
    }

    public class Media
    {
        public string Name { get; set; }

        public DateTime StartTime { get; set; }

        public Uri Url { get; set; }
    }

    public class Area
    {
        public IDictionary<string, Rect> CameraViewports { get; set; }

        public IEnumerable<string> Locations { get; set; }

        public IEnumerable<string> RfidPads { get; set; }

        public IEnumerable<string> PresentationPads { get; set; }

        public double GTRegionStart { get; set; }

        public double GTRegionStop { get; set; }
    }
}
