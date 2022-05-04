namespace TaxiBook.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Services.Interfaces;
    using Services.ViewModels.Orders;
    using Data;

    public class OrdersController : Controller
    {
        private readonly IOrderService orderService;
        private readonly TaxiBookDbContext db;

        public OrdersController(IOrderService orderService,TaxiBookDbContext db)
        {
            this.orderService = orderService;
            this.db = db;
        }

        [Authorize(Roles = "Client,TaxiDriver,Dispatcher,Manager")]
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Create(string id)
        {
            TempData["CompanyId"] = id;

            return this.View();
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

            string companyId = TempData["CompanyId"].ToString();

            await this.orderService.CreateAsync(
                 companyId,
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

        [HttpGet]
        public IActionResult Refuse(string id)
        {
            this.orderService.Refuse(id);

            return this.RedirectToActionPermanent("Overview");
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
    }
}
