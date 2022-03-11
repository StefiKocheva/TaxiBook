namespace TaxiBook.Areas.Dispatcher.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
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
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateOrderViewModel viewModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(viewModel);
            }

            await this.orderService.CreateAsync(
                viewModel.ClientName,
                viewModel.PhoneNumber,
                viewModel.StartLocation,
                viewModel.StartLocationDetails,
                viewModel.EndLocation,
                viewModel.EndLocationDetails,
                viewModel.CountOfPassengers,
                viewModel.AdditionalRequirements,
                viewModel.TaxiDriver);

            return this.RedirectToAction("Create");
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
