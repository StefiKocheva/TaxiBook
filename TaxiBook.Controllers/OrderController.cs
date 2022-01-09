namespace TaxiBook.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using TaxiBook.ViewModels.Orders;

    public class OrderController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Create(CreateOrderViewModel model)
        {
            return this.Ok();
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
