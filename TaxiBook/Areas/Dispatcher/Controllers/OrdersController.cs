namespace TaxiBook.Areas.Dispatcher.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    [Authorize]
    [Area("Dispatcher")]
    public class OrdersController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> AcceptedOrders()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> RefusedOrders()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit()
        {
            return View();
        }

        [HttpPut]
        public async Task<IActionResult> Update(string id)
        {
            return this.Ok();
        }
    }
}
