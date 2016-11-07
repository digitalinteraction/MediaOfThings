using System;
using System.Linq;
using MongoDB.Driver;
using OpenLab.Kitchen.Service.Interfaces;
using OpenLab.Kitchen.Service.Models;

namespace OpenLab.Kitchen.Repository
{
    public class ScalesRepository : IReadOnlyRepository<ScalesData>
    {
        private readonly MongoConnection _mongoConnection;

        public ScalesRepository()
        {
            _mongoConnection = new MongoConnection();
        }

        public ScalesData GetById(Guid id)
        {
            return GetAll().Single(s => s.Id == id);
        }

        public IQueryable<ScalesData> GetAll()
        {
            return _mongoConnection.GetCollection<ScalesData>("Scales").AsQueryable();
        }
    }
}
