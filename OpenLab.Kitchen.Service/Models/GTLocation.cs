using System;
using OpenLab.Kitchen.Service.Interfaces;
using OpenLab.Kitchen.Service.Values;

namespace OpenLab.Kitchen.Service.Models
{
    public class GTLocation : TimeModel, IStreamingModel
    {
        public Rect Position { get; set; }

        public double Estimated { get; set; }

        public string RoutingKey()
        {
            return "0"; // TODO: Should be routed based on person id...
        }
    }
}
