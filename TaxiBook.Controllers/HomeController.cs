namespace TaxiBook.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;
    using Models;

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return this.View();
        }

        [HttpGet]
        public async Task<IActionResult> AllCompanies()
        {
            return this.View();
        }

        [HttpGet]
        public async Task<IActionResult> Dashboard()
        {
            return this.View();
        }

        [HttpGet]
        public async Task<IActionResult> AddCompany()
        {
            return this.View();
        }

        [HttpGet]
        public async Task<IActionResult> Favorites()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
