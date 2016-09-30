using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Bson;
using MongoDB.Driver;
using OpenLab.Kitchen.Service.Interfaces;
using OpenLab.Kitchen.Service.Models;

namespace OpenLab.Kitchen.Repository
{
    public class WaterFlowRepository : IReadOnlyRepository<WaterFlow, Guid>
    {
        private readonly IMongoClient _mongoClient;
        private readonly IMongoCollection<BsonDocument> _mongoCollection;

        public WaterFlowRepository(string dbName, string collectionName)
        {
            _mongoClient = new MongoClient("mongodb://OL-Kitchen-Capture:27017");

            _mongoClient.GetDatabase("bbckitchen").RunCommandAsync((Command<BsonDocument>)"{ping:1}").Wait();

            _mongoCollection = _mongoClient.GetDatabase(dbName).GetCollection<BsonDocument>(collectionName);
        }

        public WaterFlow GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<WaterFlow> GetAll()
        {
            return _mongoCollection.FindSync(null)
        }
    }
}
