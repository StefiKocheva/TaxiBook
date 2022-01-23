namespace TaxiBook.Areas.TaxiDriver.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    [Area("TaxiDriver")]
    public class OrdersController : Controller
    {
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AcceptedOrders()
        {
            return View();
        }

        [HttpGet]
        public IActionResult RefusedOrders()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Edit()
        {
            return View();
        }

        [HttpPut]
        public IActionResult Update(string id)
        {
            return this.Ok();
        }
    }
}
