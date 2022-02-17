namespace TaxiBook.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Services.Interfaces;
    using Services.ViewModels.Orders;

    public class OrderController : Controller
    {
        private readonly IOrderService _service;

        public OrderController(IOrderService service)
        {
            this._service = service;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateOrderViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest();
            }

            var orderId = await this._service.CreateAsync(
                 model.CurrentLocation,
                 model.CurrentLocationDetails,
                 model.EndLocation,
                 model.EndLocationDetails,
                 model.CountOfPassengers,
                 model.AdditionalRequirements);

            return this.RedirectPermanent("Create");
        }

        [HttpGet]
        public IActionResult Overview(string orderId)
        {
            return this.View();
        }

        [HttpGet]
        public IActionResult Details(string orderId)
        {
            return this.View();
        }
    }
}
