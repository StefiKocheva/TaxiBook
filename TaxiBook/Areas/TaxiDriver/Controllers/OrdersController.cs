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
        private readonly IOrderService orderService;

        public OrdersController(IOrderService orderService) 
            => this.orderService = orderService;

        [HttpGet]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateOrderViewModel viewModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest();
            }

            var orderId = await this.orderService.CreateAsync(
                viewModel.CurrentLocation,
                viewModel.CurrentLocationDetails,
                viewModel.EndLocation,
                viewModel.EndLocationDetails,
                viewModel.CountOfPassengers,
                viewModel.AdditionalRequirements); 

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
        public IActionResult Details()
        {
            return this.View();
        }

        [HttpPut]
        public IActionResult Update()
        {
            return this.Ok();
        }
    }
}
