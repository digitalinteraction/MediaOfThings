using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using OpenLab.Kitchen.Service.Interfaces;
using OpenLab.Kitchen.Service.Models;

namespace OpenLab.Kitchen.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class ProductionController : Controller
    {
        private readonly IReadWriteRepository<Production> _productionRepository;

        public ProductionController(IReadWriteRepository<Production> productionRepository)
        {
            _productionRepository = productionRepository;
        }

        // GET: api/production
        [HttpGet]
        public IQueryable<Production> Get()
        {
            return _productionRepository.GetAll();
        }

        // GET api/production/5
        [HttpGet("{id}")]
        public Production Get(Guid id)
        {
            return _productionRepository.GetById(id);
        }

        // POST api/production
        [HttpPost]
        public void Post([FromBody]Production value)
        {
            _productionRepository.Insert(value);
        }

        // PUT api/production/5
        [HttpPut("{id}")]
        public void Put([FromBody]Production value)
        {
            _productionRepository.Update(value);
        }

        // DELETE api/production/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _productionRepository.Delete(_productionRepository.GetById(id));
        }
    }
}
