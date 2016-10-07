using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Driver;
using OpenLab.Kitchen.Service.Interfaces;
using OpenLab.Kitchen.Service.Models;

namespace OpenLab.Kitchen.Repository
{
    public class DatasetRepository : IReadOnlyRepository<Dataset, Guid>
    {
        private readonly MongoConnection _mongoConnection;

        public DatasetRepository()
        {
            _mongoConnection = new MongoConnection();
        }

        public Dataset GetById(Guid id)
        {
            return GetAll().Single(d => d.Id == id);
        }

        public IQueryable<Dataset> GetAll()
        {
            return _mongoConnection.GetCollection<Dataset>("Datasets").AsQueryable();
        }
    }
}
