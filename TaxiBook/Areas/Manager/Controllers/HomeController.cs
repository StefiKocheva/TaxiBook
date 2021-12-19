namespace TaxiBook.Areas.Manager.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    [Authorize]
    [Area("Manager")]
    public class HomeController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return this.View();
        }

        [HttpGet]
        public async Task<IActionResult> Schedule()
        {
            return this.View();
        }
    }
}
