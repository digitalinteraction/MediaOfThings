using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Options;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;
using OpenLab.Kitchen.Service.Models;

namespace OpenLab.Kitchen.Repository
{
    public class MongoConnection
    {
        private readonly IMongoClient _mongoClient;
        private readonly IMongoDatabase _database;

        public MongoConnection()
        {
            RegisterTypes();

            var url = MongoUrl.Create("mongodb://192.168.1.101:27017/kitchen");

            _mongoClient = new MongoClient(url);

            _database = _mongoClient.GetDatabase(url.DatabaseName);
        }

        public static void RegisterTypes()
        {
            if (BsonClassMap.IsClassMapRegistered(typeof(Wax3Data))) return;

            BsonClassMap.RegisterClassMap<Wax3Data>();
            BsonClassMap.RegisterClassMap<Wax9Data>();
            BsonClassMap.RegisterClassMap<RfidData>();
            BsonClassMap.RegisterClassMap<ScalesData>();
            BsonClassMap.RegisterClassMap<WaterFlow>();
            BsonClassMap.RegisterClassMap<Media>();
            BsonClassMap.RegisterClassMap<Production>(cm =>
            {
                cm.AutoMap();
                var stringStringSerial = new DictionaryInterfaceImplementerSerializer<Dictionary<string, string>>(DictionaryRepresentation.ArrayOfArrays);
                var intStringSerial = new DictionaryInterfaceImplementerSerializer<Dictionary<int, string>>(DictionaryRepresentation.ArrayOfArrays);
                cm.GetMemberMap(c => c.RfidConfig).SetSerializer(stringStringSerial);
                cm.GetMemberMap(c => c.SmappeeConfig).SetSerializer(intStringSerial);
                cm.GetMemberMap(c => c.Wax3Config).SetSerializer(intStringSerial);
            });
        }

        public IMongoDatabase GetDatabase()
        {
            return _database;
        }

        public async Task<IEnumerable<string>>  GetCollectionNames()
        {
            var collections = await _database.ListCollectionsAsync();
            return collections.Current.Select(c => c["name"].AsString);
        }

        public IMongoCollection<T> GetCollection<T>(string collection)
        {
            return _database.GetCollection<T>(collection);
        }
    }
}
