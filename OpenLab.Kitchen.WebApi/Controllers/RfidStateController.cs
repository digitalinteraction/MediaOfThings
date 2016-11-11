using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OpenLab.Kitchen.Service.Interfaces;
using OpenLab.Kitchen.Service.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

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
        public IEnumerable<RfidState> Get()
        {
            return _rfidStateRepository.GetAll();
        }

        // GET api/rfidstate/5
        [HttpGet("{id}")]
        public RfidState Get(Guid id)
        {
            return _rfidStateRepository.GetById(id);
        }
    }
}
