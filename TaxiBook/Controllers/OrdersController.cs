namespace TaxiBook.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Services.Interfaces;
    using Services.ViewModels.Orders;
    using TaxiBook.Data;

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

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            //await this.orderService.DeleteAsync(
            //    viewModel.Id,
            //    viewModel.ClientId);
            var order = await this.db.Orders.FindAsync(id);

            if (order == null)
            {
                return this.NotFound();
            }
            db.Remove(order);
            await db.SaveChangesAsync();

            return this.RedirectToActionPermanent("Overview");
        }
    }
}
