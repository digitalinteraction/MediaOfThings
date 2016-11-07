using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace OpenLab.Kitchen.Configure
{
    public abstract class Model
    {
        public ObjectId Id { get; set; }

        public int LocationId { get; set; }

        public string DeviceId { get; set; }

        public DateTime DataTimeStamp { get; set; }

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
