namespace TaxiBook.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class OrderController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Overview()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Details()
        {
            return View();
        }
    }
}
