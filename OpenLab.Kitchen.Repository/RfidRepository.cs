using System;
using System.Linq;
using MongoDB.Driver;
using OpenLab.Kitchen.Service.Interfaces;
using OpenLab.Kitchen.Service.Models;

namespace OpenLab.Kitchen.Repository
{
    public class RfidRepository : IReadOnlyRepository<RfidData>
    {
        private readonly MongoConnection _mongoConnection;

        public RfidRepository()
        {
            _mongoConnection = new MongoConnection();
        }

        public RfidData GetById(Guid id)
        {
            return GetAll().Single(r => r.Id == id);
        }

        public IQueryable<RfidData> GetAll()
        {
            return _mongoConnection.GetCollection<RfidData>("Rfid").AsQueryable();
        }
    }
}
