using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Remoting.Channels;
using System.Text;
using MongoDB.Bson;
using MongoDB.Driver;
using OpenLab.Kitchen.Service.Interfaces;

namespace OpenLab.Kitchen.Repository
{
    public class GenericRepository : IReadWriteRepository<string>
    {
        private readonly IMongoClient _mongoClient;
        private readonly IMongoCollection<BsonDocument> _mongoCollection;

        public GenericRepository(string dbName, string collectionName)
        {
            _mongoClient = new MongoClient("mongodb://OL-Kitchen-Capture:27017");
            _mongoCollection = _mongoClient.GetDatabase(dbName).GetCollection<BsonDocument>(collectionName);
        }

        public void Insert(string model)
        {
            throw new NotImplementedException();
        }

        public void Update(string model)
        {
            throw new NotImplementedException();
        }

        public void Delete(string model)
        {
            throw new NotImplementedException();
        }

        public string GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<string> Search(Expression<Func<string, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IQueryable<string> GetAll()
        {
            _mongoCollection
        }
    }
}
