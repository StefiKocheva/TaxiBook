namespace TaxiBook.Areas.Dispatcher.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Services.Interfaces;
    using ViewModels.Orders;

    [Authorize(Roles = "Dispatcher")]
    [Area("Dispatcher")]
    public class OrdersController : Controller
    {
        private readonly IOrderService orderService;

        public OrdersController(IOrderService orderService) 
            => this.orderService = orderService;

        [HttpGet]
        public IActionResult Create()
        {
            var viewModel = new ListingViewModel
            {
                AvailableDrivers = this.orderService.GetAvailableDriversDetails()
            };

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ListingViewModel viewModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(viewModel);
            }

            await this.orderService.CreateAsync(
                viewModel.CreateOrderViewModel.ClientName,
                viewModel.CreateOrderViewModel.PhoneNumber,
                viewModel.CreateOrderViewModel.StartLocation,
                viewModel.CreateOrderViewModel.StartLocationDetails,
                viewModel.CreateOrderViewModel.EndLocation,
                viewModel.CreateOrderViewModel.EndLocationDetails,
                viewModel.CreateOrderViewModel.CountOfPassengers,
                viewModel.CreateOrderViewModel.AdditionalRequirements,
                viewModel.CreateOrderViewModel.TaxiDriver);

            return this.RedirectToAction("Create");
        }

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            var viewModel = await this.orderService.DetailsAsync(id);

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Process(string id)
        {
            await this.orderService.ProcessAsync(id);

            return this.RedirectToActionPermanent("Unprocessed");
        }

        [HttpGet]
        public IActionResult Processed()
        {
            var viewModel = new OrderListingViewModel
            {
                ProcessedOrders = this.orderService.GetAllProcessedOrders()
            };

            return this.View(viewModel);
        }

        [HttpGet]
        public IActionResult Unprocessed()
        {
            var viewModel = new OrderListingViewModel
            {
                UnprocessedOrders = this.orderService.GetAllUnprocessedOrders()
            };

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Unaccept(string id)
        {
            await this.orderService.UnacceptAsync(id);

            return this.RedirectToActionPermanent("Unprocessed");
        }

        [HttpGet]
        public IActionResult Refused()
        {
            var viewModel = new OrderListingViewModel
            {
                RefusedOrders = this.orderService.GetAllRefusedOrders()
            };

            return this.View(viewModel);
        }
    }
}
