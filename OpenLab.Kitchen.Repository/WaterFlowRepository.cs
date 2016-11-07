using System;
using System.Linq;
using MongoDB.Driver;
using OpenLab.Kitchen.Service.Interfaces;
using OpenLab.Kitchen.Service.Models;

namespace OpenLab.Kitchen.Repository
{
    public class WaterFlowRepository : IReadOnlyRepository<WaterFlow>
    {
        private readonly MongoConnection _mongoConnection;

        public WaterFlowRepository()
        {
            _mongoConnection = new MongoConnection();
        }

        public WaterFlow GetById(Guid id)
        {
            return GetAll().Single(w => w.Id == id);
        }

        public IQueryable<WaterFlow> GetAll()
        {
            return _mongoConnection.GetCollection<WaterFlow>("WaterFlow").AsQueryable();
        }
    }
}
