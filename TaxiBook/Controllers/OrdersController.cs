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
            var viewModel = new OrderListingViewModel()
            {
                Orders = this.orderService.OverviewPast(),
            };

            return this.View(viewModel);
        }

        [Authorize(Roles = "Client")]
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Create(CreateOrderViewModel viewModel)
        {
            if (!this.ModelState.IsValid)
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
        public IActionResult Overview()
        {
            var viewModel = new OrderListingViewModel()
            {
                Orders = this.orderService.Overview(),
            };

            return this.View(viewModel);
        }
    }
}
