using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace OpenLab.Kitchen.Configure
{
    public class ScalesData : Model
    {
        [BsonRepresentation(BsonType.Double, AllowTruncation = true)]
        public float Weight { get; set; }
    }
}
