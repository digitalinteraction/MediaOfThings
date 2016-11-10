using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Driver;
using OpenLab.Kitchen.Service.Interfaces;
using OpenLab.Kitchen.Service.Models;

namespace OpenLab.Kitchen.Repository
{
    public class MongoRepository<T> : IReadOnlyRepository<T> where T : Model
    {
        private readonly MongoConnection _mongoConnection;
        private readonly string _collectionName;

        public MongoRepository(string connectionString, string collectionName)
        {
            _mongoConnection = new MongoConnection(connectionString);
            _collectionName = collectionName;
        }

        public IQueryable<T> GetAll()
        {
            return _mongoConnection.GetCollection<T>(_collectionName).AsQueryable();
        }

        public T GetById(Guid id)
        {
            return GetAll().Single(p => p.Id == id);
        }
    }
}
