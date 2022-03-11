namespace TaxiBook.Areas.TaxiDriver.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Services.Inerfaces;
    using ViewModels.Orders;

    [Authorize(Roles = "TaxiDriver")]
    [Area("TaxiDriver")]
    public class OrdersController : Controller
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService) => this._orderService = orderService;

        [HttpGet]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateOrderViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest();
            }

            var orderId = await this._orderService.CreateAsync(
                model.CurrentLocation,
                model.CurrentLocationDetails,
                model.EndLocation,
                model.EndLocationDetails,
                model.CountOfPassengers,
                model.AdditionalRequirements); 

            return this.RedirectPermanent("Create");
        }

        [HttpGet]
        public IActionResult Unaccepted()
        {
            return this.View();
        }

        [HttpGet]
        public IActionResult Overview()
        {
            return this.View();
        }

        [HttpGet]
        public IActionResult Accepted()
        {
            return this.View();
        }

        [HttpGet]
        public IActionResult Refused()
        {
            return this.View();
        }

        [HttpGet]
        public IActionResult Edit(string userId)
        {
            return this.View();
        }

        [HttpPut]
        public IActionResult Update(string id)
        {
            return this.Ok();
        }
    }
}
