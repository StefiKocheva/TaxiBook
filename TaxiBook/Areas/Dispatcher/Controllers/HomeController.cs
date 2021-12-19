namespace TaxiBook.Areas.Dispatcher.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    [Authorize]
    [Area("Dispatcher")]
    public class HomeController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Schedule()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Track()
        {
            return View();
        }
    }
}
