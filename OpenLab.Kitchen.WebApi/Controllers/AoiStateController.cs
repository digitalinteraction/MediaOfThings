using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OpenLab.Kitchen.Service.Interfaces;
using OpenLab.Kitchen.Service.Models;

namespace OpenLab.Kitchen.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class AoiStateController : Controller
    {
        private readonly IReadOnlyRepository<AoiState> _aoiStateRepository;

        public AoiStateController(IReadOnlyRepository<AoiState> aoiStateRepository)
        {
            _aoiStateRepository = aoiStateRepository;
        }

        // GET: api/aoistate
        [HttpGet]
        public IQueryable<AoiState> Get()
        {
            return _aoiStateRepository.GetAll();
        }

        // GET api/aoistate/timerange?start={start}&end={end}
        [HttpGet("timerange")]
        public IQueryable<AoiState> Get(DateTime start, DateTime end)
        {
            return Get().Where(w => w.Timestamp >= start.ToUniversalTime() && w.Timestamp < end.ToUniversalTime());
        }

        // GET api/aoistate/5
        [HttpGet("{id}")]
        public AoiState Get(Guid id)
        {
            return _aoiStateRepository.GetById(id);
        }
    }
}
