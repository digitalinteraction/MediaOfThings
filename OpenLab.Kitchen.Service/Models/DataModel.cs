using System;

namespace OpenLab.Kitchen.Service.Models
{
    public abstract class DataModel : Model
    {
        public DateTime Timestamp { get; set; }

        public abstract string IdString();
    }
}
