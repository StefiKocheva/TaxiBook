namespace TaxiBook.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Services.Interfaces;
    using Services.ViewModels.Orders;

    public class OrdersController : Controller
    {
        private readonly IOrderService orderService;

        public OrdersController(IOrderService orderService) 
            => this.orderService = orderService;

        [Authorize(Roles = "Client,TaxiDriver,Dispatcher,Manager")]
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Create()
        {
            return this.View();
        }

        [Authorize(Roles = "Client")]
        [HttpGet]
        public IActionResult Past()
        {
            return this.View();
        }

        [Authorize(Roles = "Client")]
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Create(CreateOrderViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return this.View(viewModel);
            }

            await this.orderService.CreateAsync(
                 viewModel.CurrentLocation,
                 viewModel.CurrentLocationDetails,
                 viewModel.EndLocation,
                 viewModel.EndLocationDetails,
                 viewModel.CountOfPassengers,
                 viewModel.AdditionalRequirements);

            return this.RedirectToAction("Overview");
        }

        [Authorize(Roles = "Client")]
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Overview(string id)
        {
            return this.View();
        }
    }
}
