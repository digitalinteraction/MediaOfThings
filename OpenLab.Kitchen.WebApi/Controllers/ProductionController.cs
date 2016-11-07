using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OpenLab.Kitchen.Service.Interfaces;
using OpenLab.Kitchen.Service.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace OpenLab.Kitchen.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class ProductionController : Controller
    {
        private readonly IReadOnlyRepository<Production> _productionRepository;

        public ProductionController(IReadOnlyRepository<Production> productionRepository)
        {
            _productionRepository = productionRepository;
        }

        // GET: api/production
        [HttpGet]
        public IEnumerable<Production> Get()
        {
            return _productionRepository.GetAll();
        }

        // GET api/production/5
        [HttpGet("{id}")]
        public Production Get(Guid id)
        {
            return _productionRepository.GetById(id);
        }
    }
}
