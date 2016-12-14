using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using OpenLab.Kitchen.Service.Interfaces;
using OpenLab.Kitchen.Service.Models;

namespace OpenLab.Kitchen.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class RfidStateController : Controller
    {
        private readonly IReadOnlyRepository<RfidState> _rfidStateRepository;

        public RfidStateController(IReadOnlyRepository<RfidState> productionRepository)
        {
            _rfidStateRepository = productionRepository;
        }

        // GET: api/rfidstate
        [HttpGet]
        public IQueryable<RfidState> Get()
        {
            return _rfidStateRepository.GetAll();
        }

        // GET api/rfidstate/timerange?start={start}&end={end}
        [HttpGet("timerange")]
        public IQueryable<RfidState> Get(DateTime start, DateTime end)
        {
            return Get().Where(w => w.Timestamp >= start.ToUniversalTime() && w.Timestamp < end.ToUniversalTime());
        }

        // GET api/rfidstate/5
        [HttpGet("{id}")]
        public RfidState Get(Guid id)
        {
            return _rfidStateRepository.GetById(id);
        }
    }
}
