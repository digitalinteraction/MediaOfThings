using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using OpenLab.Kitchen.Service.Interfaces;
using OpenLab.Kitchen.Service.Models;

namespace OpenLab.Kitchen.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class Wax9Controller : Controller
    {
        private readonly IReadOnlyRepository<Wax9Data> _wax9Repository;

        public Wax9Controller(IReadOnlyRepository<Wax9Data> wax9Repository)
        {
            _wax9Repository = wax9Repository;
        }

        // GET api/wax9
        [HttpGet]
        public IQueryable<Wax9Data> Get()
        {
            return _wax9Repository.GetAll();
        }

        // GET api/wax9/timerange?start={start}&end={end}
        [HttpGet("timerange")]
        public IQueryable<Wax9Data> Get(DateTime start, DateTime end)
        {
            return Get().Where(w => w.Timestamp >= start.ToUniversalTime() && w.Timestamp < end.ToUniversalTime());
        }

        // GET api/wax9/5
        [HttpGet("{id}")]
        public Wax9Data Get(Guid id)
        {
            return _wax9Repository.GetById(id);
        }
    }
}
