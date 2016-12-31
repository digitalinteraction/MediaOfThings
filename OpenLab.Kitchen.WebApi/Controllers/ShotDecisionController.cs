using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using OpenLab.Kitchen.Service.Interfaces;
using OpenLab.Kitchen.Service.Models;

namespace OpenLab.Kitchen.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class ShotDecisionController : Controller
    {
        private readonly IReadOnlyRepository<ShotDecision> _shotDecisionRepository;

        public ShotDecisionController(IReadOnlyRepository<ShotDecision> shotDecisionRepository)
        {
            _shotDecisionRepository = shotDecisionRepository;
        }

        // GET: api/shotdecision
        [HttpGet]
        public IQueryable<ShotDecision> Get()
        {
            return _shotDecisionRepository.GetAll();
        }

        // GET api/shotdecision/timerange?start={start}&end={end}
        [HttpGet("timerange")]
        public IQueryable<ShotDecision> Get(DateTime start, DateTime end)
        {
            return Get().Where(w => w.Timestamp >= start.ToUniversalTime() && w.Timestamp < end.ToUniversalTime());
        }

        // GET api/shotdecision/5
        [HttpGet("{id}")]
        public ShotDecision Get(Guid id)
        {
            return _shotDecisionRepository.GetById(id);
        }
    }
}
