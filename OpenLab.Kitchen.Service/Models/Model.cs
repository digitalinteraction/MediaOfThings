using System;

namespace OpenLab.Kitchen.Service.Models
{
    public abstract class Model
    {
        public Guid Id { get; set; }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return GetHashCode() == obj.GetHashCode();
        }
    }
}
