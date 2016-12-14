using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using OpenLab.Kitchen.Service.Interfaces;
using OpenLab.Kitchen.Service.Models;

namespace OpenLab.Kitchen.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class RfidController : Controller
    {
        private readonly IReadOnlyRepository<RfidData> _rfidRepository;

        public RfidController(IReadOnlyRepository<RfidData> rfidRepository)
        {
            _rfidRepository = rfidRepository;
        }

        // GET api/rfid
        [HttpGet]
        public IQueryable<RfidData> Get()
        {
            return _rfidRepository.GetAll();
        }

        // GET api/rfid/timerange?start={start}&end={end}
        [HttpGet("timerange")]
        public IQueryable<RfidData> Get(DateTime start, DateTime end)
        {
            return Get().Where(w => w.Timestamp >= start.ToUniversalTime() && w.Timestamp < end.ToUniversalTime());
        }

        // GET api/rfid/5
        [HttpGet("{id}")]
        public RfidData Get(Guid id)
        {
            return _rfidRepository.GetById(id);
        }
    }
}
