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
        public IEnumerable<AoiState> Get()
        {
            return _aoiStateRepository.GetAll();
        }

        // GET api/aoistate/5
        [HttpGet("{id}")]
        public AoiState Get(Guid id)
        {
            return _aoiStateRepository.GetById(id);
        }
    }
}
