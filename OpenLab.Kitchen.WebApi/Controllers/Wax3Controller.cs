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
    public class Wax3Controller : Controller
    {
        private readonly IReadOnlyRepository<Wax3Data> _wax3Repository;

        public Wax3Controller(IReadOnlyRepository<Wax3Data> wax3Repository)
        {
            _wax3Repository = wax3Repository;
        }

        // GET api/wax3?starttime=1000?endtime=2000
        [HttpGet("{starttime:datetime}/{endtime:datetime}")]
        public IEnumerable<Wax3Data> Get(DateTime starttime, DateTime endTime)
        {
            return _wax3Repository.GetAll().Where(w => w.TimeStamp >= starttime && w.TimeStamp <= endTime);
        }

        // GET api/wax3/5
        [HttpGet("{id}")]
        public Wax3Data Get(Guid id)
        {
            return _wax3Repository.GetById(id);
        }
    }
}
