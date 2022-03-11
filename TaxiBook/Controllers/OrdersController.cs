﻿namespace TaxiBook.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Services.Interfaces;
    using Services.ViewModels.Orders;

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

        [HttpGet]
        public IActionResult Past()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateOrderViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return this.View(viewModel);
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