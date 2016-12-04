using Microsoft.AspNetCore.Mvc;

namespace OpenLab.Kitchen.Viewer.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
