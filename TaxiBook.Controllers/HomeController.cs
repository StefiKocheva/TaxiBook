namespace TaxiBook.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return this.View();
        }

        [HttpGet]
        public IActionResult Dashboard()
        {
            return this.View();
        }

        [HttpGet]
        public IActionResult Favorites()
        {
            return this.View();
        }
    }
}
