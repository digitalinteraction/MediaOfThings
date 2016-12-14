using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using OpenLab.Kitchen.Service.Interfaces;
using OpenLab.Kitchen.Service.Models;

namespace OpenLab.Kitchen.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class Wax3Controller : Controller
    {
        private readonly IReadOnlyRepository<Wax3Data> _wax3Repository;

        public Wax3Controller(IReadOnlyRepository<Wax3Data> wax3Repository)
        {
            _wax3Repository = wax3Repository;
        }

        // GET api/wax3
        [HttpGet]
        public IQueryable<Wax3Data> Get()
        {
            return _wax3Repository.GetAll();
        }

        // GET api/wax3/timerange?start={start}&end={end}
        [HttpGet("timerange")]
        public IQueryable<Wax3Data> Get(DateTime start, DateTime end)
        {
            return Get().Where(w => w.Timestamp >= start.ToUniversalTime() && w.Timestamp < end.ToUniversalTime());
        }

        // GET api/wax3/5
        [HttpGet("{id}")]
        public Wax3Data Get(Guid id)
        {
            return _wax3Repository.GetById(id);
        }
    }
}
