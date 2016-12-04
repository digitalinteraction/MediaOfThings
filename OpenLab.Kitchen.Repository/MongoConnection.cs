using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Options;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;
using OpenLab.Kitchen.Service.Models;

namespace OpenLab.Kitchen.Repository
{
    public class MongoConnection<T> where T : Model
    {
        private readonly IMongoClient _mongoClient;
        private readonly IMongoDatabase _database;
        private readonly string _collectionName;

        public MongoConnection(string connectionString, string collectionName)
        {
            RegisterTypes();

            var url = MongoUrl.Create(connectionString);

            _mongoClient = new MongoClient(url);

            _database = _mongoClient.GetDatabase(url.DatabaseName);
            _collectionName = collectionName;
        }

        public static void RegisterTypes()
        {
            if (BsonClassMap.IsClassMapRegistered(typeof(Wax3Data))) return;

            BsonClassMap.RegisterClassMap<Wax3Data>();
            BsonClassMap.RegisterClassMap<Wax3State>();
            BsonClassMap.RegisterClassMap<Wax9Data>();
            BsonClassMap.RegisterClassMap<RfidData>();
            BsonClassMap.RegisterClassMap<RfidState>();
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

        public IEnumerable<string>  GetCollectionNames()
        {
            var collections = _database.ListCollectionsAsync();
            collections.Wait();
            return collections.Result.Current.Select(c => c["name"].AsString);
        }

        public IMongoCollection<T> GetCollection()
        {
            return _database.GetCollection<T>(_collectionName);
        }

        public void Insert(T model)
        {
            GetCollection().InsertOne(model);
        }

        public void InsertMany(IEnumerable<T> models)
        {
            GetCollection().InsertMany(models);
        }

        public void Update(T model)
        {
            GetCollection().ReplaceOneAsync(d => d.Id == model.Id, model).Wait();
        }

        public void Delete(T model)
        {
            GetCollection().DeleteOne(d => d.Id == model.Id);
        }
    }
}
