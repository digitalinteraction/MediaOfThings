using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;
using OpenLab.Kitchen.Service.Interfaces;
using OpenLab.Kitchen.Service.Models;

namespace OpenLab.Kitchen.Repository
{
    public class ScalesRepository : IReadOnlyRepository<ScalesData, Guid>
    {
        private readonly IMongoClient _mongoClient;
        private readonly IMongoCollection<BsonDocument> _mongoCollection;

        public ScalesRepository(string dbName, string collectionName)
        {
            _mongoClient = new MongoClient("mongodb://OL-Kitchen-Capture:27017");

            _mongoClient.GetDatabase("bbckitchen").RunCommandAsync((Command<BsonDocument>)"{ping:1}").Wait();

            _mongoCollection = _mongoClient.GetDatabase(dbName).GetCollection<BsonDocument>(collectionName);
        }

        public IQueryable<ScalesData> GetAll()
        {
            return
                _mongoCollection.FindSync(null)
                    .ToEnumerable()
                    .Select(d => JsonConvert.DeserializeObject<ScalesData>(d))
                    .AsQueryable();
        }

        public ScalesData GetById(Guid id)
        {
            return GetAll().Single(s => s.Id == id);
        }
    }
}
