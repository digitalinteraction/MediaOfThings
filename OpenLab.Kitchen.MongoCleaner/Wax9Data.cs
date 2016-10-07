using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace OpenLab.Kitchen.MongoCleaner
{
    public class Wax9Data : Model
    {
        public int SampleNumber { get; set; }

        [BsonRepresentation(BsonType.Double, AllowTruncation = true)]
        public float AccX { get; set; }

        [BsonRepresentation(BsonType.Double, AllowTruncation = true)]
        public float AccY { get; set; }

        [BsonRepresentation(BsonType.Double, AllowTruncation = true)]
        public float AccZ { get; set; }

        [BsonRepresentation(BsonType.Double, AllowTruncation = true)]
        public float GyroX { get; set; }

        [BsonRepresentation(BsonType.Double, AllowTruncation = true)]
        public float GyroY { get; set; }

        [BsonRepresentation(BsonType.Double, AllowTruncation = true)]
        public float GyroZ { get; set; }

        [BsonRepresentation(BsonType.Double, AllowTruncation = true)]
        public float MagX { get; set; }

        [BsonRepresentation(BsonType.Double, AllowTruncation = true)]
        public float MagY { get; set; }

        [BsonRepresentation(BsonType.Double, AllowTruncation = true)]
        public float MagZ { get; set; }
    }
}