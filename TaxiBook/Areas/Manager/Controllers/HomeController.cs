using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace TaxiBook.Areas.Manager.Controllers
{
    [Authorize]
    [Area("Manager")]
    public class HomeController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return Ok("Works");
        }

        public async Task<IActionResult> Schedule()
        {
            return Ok("Works");
        }
    }
}
