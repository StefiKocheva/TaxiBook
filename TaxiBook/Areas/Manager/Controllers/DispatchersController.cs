namespace TaxiBook.Areas.Manager.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    [Authorize]
    [Area("Manager")]
    public class DispatchersController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> All()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit()
        {
            return View();
        }
    }
}
