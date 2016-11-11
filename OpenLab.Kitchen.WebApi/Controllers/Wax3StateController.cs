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
    public class Wax3StateController : Controller
    {
        private readonly IReadOnlyRepository<Wax3State> _wax3StateRepository;

        public Wax3StateController(IReadOnlyRepository<Wax3State> productionRepository)
        {
            _wax3StateRepository = productionRepository;
        }

        // GET: api/wax3state
        [HttpGet]
        public IEnumerable<Wax3State> Get()
        {
            return _wax3StateRepository.GetAll();
        }

        // GET api/wax3state/5
        [HttpGet("{id}")]
        public Wax3State Get(Guid id)
        {
            return _wax3StateRepository.GetById(id);
        }
    }
}
