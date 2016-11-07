using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OpenLab.Kitchen.Service.Interfaces;
using OpenLab.Kitchen.Service.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace OpenLab.Kitchen.Viewer.Controllers
{
    public class ProductionController : Controller
    {
        private readonly IReadOnlyRepository<Production> _productionRepository;

        public ProductionController(IReadOnlyRepository<Production> productionRepository)
        {
            _productionRepository = productionRepository;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View(_productionRepository.GetAll());
        }

        // GET: /<controller>/detail/{id}
        public IActionResult Detail(Guid id)
        {
            return View(_productionRepository.GetById(id));
        }

        public IActionResult Player(Guid productionId, int take)
        {
            ViewBag.Take = take;

            return View(_productionRepository.GetById(productionId));
        }
    }
}
