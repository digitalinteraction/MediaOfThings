using System;
using System.Linq;
using MongoDB.Driver;
using OpenLab.Kitchen.Service.Interfaces;
using OpenLab.Kitchen.Service.Models;

namespace OpenLab.Kitchen.Repository
{
    public class Wax3Repository : IReadOnlyRepository<Wax3Data>
    {
        private readonly MongoConnection _mongoConnection;

        public Wax3Repository()
        {
            _mongoConnection = new MongoConnection();
        }

        public Wax3Data GetById(Guid id)
        {
            return GetAll().Single(w => w.Id == id);
        }

        public IQueryable<Wax3Data> GetAll()
        {
            return _mongoConnection.GetCollection<Wax3Data>("Wax3").AsQueryable();
        }
    }
}
