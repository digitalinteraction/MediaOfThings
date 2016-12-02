using System;

namespace OpenLab.Kitchen.Service.Models
{
    public class GTLocation : Model
    {
        public DateTime Timestamp { get; set; }

        public Rect Position { get; set; }

        public double Estimated { get; set; }
    }
}
