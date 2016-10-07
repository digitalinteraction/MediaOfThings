using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OpenLab.Kitchen.Service.Interfaces;
using OpenLab.Kitchen.Service.Models;

namespace OpenLab.Kitchen.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class DatasetController : Controller
    {
        private readonly IReadOnlyRepository<Dataset, Guid> _datasetRepository;

        public DatasetController(IReadOnlyRepository<Dataset, Guid> datasetRepository)
        {
            _datasetRepository = datasetRepository;
        }

        // GET api/dataset
        [HttpGet]
        public IEnumerable<Dataset> Get()
        {
            return _datasetRepository.GetAll();
        }

        // GET api/dataset/5
        [HttpGet("{id}")]
        public Dataset Get(Guid id)
        {
            return _datasetRepository.GetById(id);
        }
    }
}
