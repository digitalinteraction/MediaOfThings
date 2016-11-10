using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Newtonsoft.Json;
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

        // GET api/rfid?starttime=1000?endtime=2000
        [HttpGet("{starttime:datetime}/{endtime:datetime}")]
        public IEnumerable<RfidData> Get(DateTime starttime, DateTime endtime)
        {
            return _rfidRepository.GetAll().Where(r => r.Timestamp >= starttime && r.Timestamp <= endtime);
        }

        // GET api/rfid/5
        [HttpGet("{id}")]
        public RfidData Get(Guid id)
        {
            return _rfidRepository.GetById(id);
        }
    }
}
