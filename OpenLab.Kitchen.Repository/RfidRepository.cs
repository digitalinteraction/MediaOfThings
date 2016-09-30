using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json;
using OpenLab.Kitchen.Service.Interfaces;
using OpenLab.Kitchen.Service.Models;

namespace OpenLab.Kitchen.Repository
{
    public class RfidRepository : IReadOnlyRepository<Wax9Data, Guid>
    {
        private readonly IMongoClient _mongoClient;
        private readonly IMongoCollection<BsonDocument> _mongoCollection;

        public RfidRepository(string dbName, string collectionName)
        {
            _mongoClient = new MongoClient("mongodb://OL-Kitchen-Capture:27017");

            _mongoClient.GetDatabase("bbckitchen").RunCommandAsync((Command<BsonDocument>)"{ping:1}").Wait();

            _mongoCollection = _mongoClient.GetDatabase(dbName).GetCollection<RfidData>(collectionName);
        }

        public IQueryable<Wax9Data> GetAll()
        {
            return
                _mongoCollection.FindSync(Builders<Wax9Data>.Filter.OfType())
                    .ToEnumerable()
                    .Select(d => JsonConvert.DeserializeObject<Wax9Data>(d.ToJson()))
                    .AsQueryable();
        }

        public Wax9Data GetById(Guid id)
        {
            return GetAll().Single(w => w.Id == id);
        }
    }
}
