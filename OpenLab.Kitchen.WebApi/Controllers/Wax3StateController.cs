using System;
using Microsoft.AspNetCore.Mvc;
using OpenLab.Kitchen.Service.Interfaces;
using OpenLab.Kitchen.Service.Models;
using System.Linq;

namespace OpenLab.Kitchen.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class Wax3StateController : Controller
    {
        private readonly IReadOnlyRepository<Wax3State> _wax3StateRepository;

        public Wax3StateController(IReadOnlyRepository<Wax3State> productionRepository)
        {
            _wax3StateRepository = productionRepository;
        }

        // GET: api/wax3state
        [HttpGet]
        public IQueryable<Wax3State> Get()
        {
            return _wax3StateRepository.GetAll();
        }

        // GET api/wax3state/timerange?start={start}&end={end}
        [HttpGet("timerange")]
        public IQueryable<Wax3State> Get(DateTime start, DateTime end)
        {
            return Get().Where(w => w.Timestamp >= start.ToUniversalTime() && w.Timestamp < end.ToUniversalTime());
        }

        // GET api/wax3state/5
        [HttpGet("{id}")]
        public Wax3State Get(Guid id)
        {
            return _wax3StateRepository.GetById(id);
        }
    }
}
