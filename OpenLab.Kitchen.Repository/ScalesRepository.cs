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
