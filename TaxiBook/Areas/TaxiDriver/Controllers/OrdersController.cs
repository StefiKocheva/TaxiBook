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
            =>  this.View();

        [HttpPost]
        public async Task<IActionResult> Create(CreateOrderViewModel viewModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest();
            }

            await this.orderService.CreateAsync(
                viewModel.EndLocation,
                viewModel.CountOfPassengers);

            return this.RedirectToAction("Overview");
        }

        [HttpGet]
        public IActionResult Unaccepted()
        {
            var viewModel = new OrderListingViewModel
            {
                UnacceptedOrders = this.orderService.GetAllUnacceptedOrders(),
            };
            
            return this.View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Overview()
        {
            var viewModel = await this.orderService.OverviewAsync();

            return this.View(viewModel);
        }

        [HttpGet]
        public IActionResult Accepted()
        {
            var viewModel = new OrderListingViewModel
            {
                AcceptedOrders = this.orderService.GetAllAcceptedOrders(),
            };

            return this.View(viewModel);
        }

        [HttpGet]
        public IActionResult Refused()
        {
            var viewModel = new OrderListingViewModel
            {
                RefusedOrders = this.orderService.GetAllRefusedOrders(),
            };

            return this.View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Details(string id)
        {
            var viewModel = await this.orderService.DetailsAsync(id);

            return this.View(viewModel);
        }
    }
}
