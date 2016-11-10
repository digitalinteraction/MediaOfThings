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
    public class WaterFlowController : Controller
    {
        private readonly IReadOnlyRepository<WaterFlow> _waterFlowRepository;

        public WaterFlowController(IReadOnlyRepository<WaterFlow> waterFlowRepository)
        {
            _waterFlowRepository = waterFlowRepository;
        }

        // GET api/waterflow?starttime=1000?endtime=2000
        [HttpGet("{starttime:datetime}/{endtime:datetime}")]
        public IEnumerable<WaterFlow> Get(DateTime starttime, DateTime endTime)
        {
            return _waterFlowRepository.GetAll().Where(w => w.Timestamp >= starttime && w.Timestamp <= endTime);
        }

        // GET api/waterflow/5
        [HttpGet("{id}")]
        public WaterFlow Get(Guid id)
        {
            return _waterFlowRepository.GetById(id);
        }
    }
}
