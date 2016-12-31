using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using OpenLab.Kitchen.Service.Interfaces;
using OpenLab.Kitchen.Service.Models;

namespace OpenLab.Kitchen.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class WaterFlowController : Controller
    {
        private readonly IReadOnlyRepository<WaterFlow> _waterFlowRepository;

        public WaterFlowController(IReadOnlyRepository<WaterFlow> waterFlowRepository)
        {
            _waterFlowRepository = waterFlowRepository;
        }

        // GET api/waterflow
        [HttpGet]
        public IQueryable<WaterFlow> Get()
        {
            return _waterFlowRepository.GetAll();
        }

        // GET api/waterflow?start={start}&end={end}
        [HttpGet("timerange")]
        public IQueryable<WaterFlow> Get(DateTime start, DateTime end)
        {
            return Get().Where(w => w.Timestamp >= start.ToUniversalTime() && w.Timestamp < end.ToUniversalTime());
        }

        // GET api/waterflow/5
        [HttpGet("{id}")]
        public WaterFlow Get(Guid id)
        {
            return _waterFlowRepository.GetById(id);
        }
    }
}
