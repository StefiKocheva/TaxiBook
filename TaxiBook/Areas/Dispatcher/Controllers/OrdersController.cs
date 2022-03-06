namespace TaxiBook.Areas.Dispatcher.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Services.Interfaces;
    using ViewModels.Orders;

    [Authorize]
    [Area("Dispatcher")]
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
                model.ClientName,
                model.PhoneNumber,
                model.CurrentLocation,
                model.CurrentLocationDetails,
                model.EndLocation,
                model.EndLocationDetails,
                model.CountOfPassengers,
                model.AdditionalRequirements,
                model.TaxiDriver); // TaxiDriver.FullName -> FirstName + LastName
        
            return this.RedirectPermanent("Create");
        }

        [HttpGet]
        public IActionResult Processed()
        {
            return this.View();
        }

        [HttpGet]
        public IActionResult Refused()
        {
            return this.View();
        }

        [HttpGet]
        public IActionResult Unprocessed()
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
