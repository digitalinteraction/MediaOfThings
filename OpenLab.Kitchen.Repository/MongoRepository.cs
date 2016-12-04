using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;
using OpenLab.Kitchen.Service.Interfaces;
using OpenLab.Kitchen.Service.Models;

namespace OpenLab.Kitchen.Repository
{
    public class MongoRepository<T> : IReadWriteRepository<T> where T : Model
    {
        private readonly MongoConnection<T> _mongoConnection;

        public MongoRepository(string connectionString)
        {
            _mongoConnection = new MongoConnection<T>(connectionString, typeof(T).Name);
        }

        public IQueryable<T> GetAll()
        {
            return _mongoConnection.GetCollection().AsQueryable();
        }

        public T GetById(Guid id)
        {
            return GetAll().Single(p => p.Id == id);
        }

        public void Insert(T model)
        {
            _mongoConnection.Insert(model);
        }

        public void InsertMany(IEnumerable<T> models)
        {
            _mongoConnection.InsertMany(models);
        }

        public void Update(T model)
        {
            _mongoConnection.Update(model);
        }

        public void Delete(T model)
        {
            _mongoConnection.Delete(model);
        }
    }
}
