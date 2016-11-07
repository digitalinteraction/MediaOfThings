using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Driver;
using OpenLab.Kitchen.Service.Interfaces;
using OpenLab.Kitchen.Service.Models;

namespace OpenLab.Kitchen.Repository
{
    public class ProductionRepository : IReadOnlyRepository<Production>
    {
        private MongoConnection _mongoConnection;

        public ProductionRepository()
        {
            _mongoConnection = new MongoConnection();
        }

        public IQueryable<Production> GetAll()
        {
            return _mongoConnection.GetCollection<Production>("Productions").AsQueryable();
        }

        public Production GetById(Guid id)
        {
            return GetAll().Single(p => p.Id == id);
        }
    }
}
