using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization;
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
            BsonClassMap.RegisterClassMap<Wax3Data>();
            BsonClassMap.RegisterClassMap<Wax9Data>();
            BsonClassMap.RegisterClassMap<RfidData>();
            BsonClassMap.RegisterClassMap<ScalesData>();
            BsonClassMap.RegisterClassMap<WaterFlow>();
            BsonClassMap.RegisterClassMap<Dataset>();
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
