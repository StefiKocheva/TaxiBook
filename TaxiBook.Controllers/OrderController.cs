namespace TaxiBook.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Services.Models.Orders;

    public class OrderController : Controller
    {
        [HttpPost]
        public IActionResult Create(CreateOrderViewModel model)
        {
            return this.Ok();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpGet]
        public IActionResult Overview()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Details()
        {
            return View();
        }
    }
}
