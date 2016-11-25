using System;

namespace OpenLab.Kitchen.Service.Models
{
    public class GTLocation : Model
    {
        public DateTime Timestamp { get; set; }

        public Rect Position { get; set; }
    }

    public struct Rect
    {
        public float X;
        public float Y;
        public float Width;
        public float Height;
    }
}
