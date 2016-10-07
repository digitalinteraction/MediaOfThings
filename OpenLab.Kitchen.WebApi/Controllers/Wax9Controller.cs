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
    public class Wax9Controller : Controller
    {
        private readonly IReadOnlyRepository<Wax9Data, Guid> _wax9Repository;

        public Wax9Controller(IReadOnlyRepository<Wax9Data, Guid> wax9Repository)
        {
            _wax9Repository = wax9Repository;
        }

        // GET api/wax9?starttime=1000?endtime=2000
        [HttpGet("{starttime:datetime}/{endtime:datetime}")]
        public IEnumerable<Wax9Data> Get(DateTime starttime, DateTime endTime)
        {
            return _wax9Repository.GetAll().Where(w => w.TimeStamp >= starttime && w.TimeStamp <= endTime);
        }

        // GET api/wax9/5
        [HttpGet("{id}")]
        public Wax9Data Get(Guid id)
        {
            return _wax9Repository.GetById(id);
        }
    }
}
