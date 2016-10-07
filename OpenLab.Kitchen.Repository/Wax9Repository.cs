using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Driver;
using OpenLab.Kitchen.Service.Interfaces;
using OpenLab.Kitchen.Service.Models;

namespace OpenLab.Kitchen.Repository
{
    public class Wax9Repository : IReadOnlyRepository<Wax9Data, Guid>
    {
        private readonly MongoConnection _mongoConnection;

        public Wax9Repository()
        {
            _mongoConnection = new MongoConnection();
        }

        public Wax9Data GetById(Guid id)
        {
            return GetAll().Single(w => w.Id == id);
        }

        public IQueryable<Wax9Data> GetAll()
        {
            return _mongoConnection.GetCollection<Wax9Data>("Wax3").AsQueryable();
        }
    }
}
