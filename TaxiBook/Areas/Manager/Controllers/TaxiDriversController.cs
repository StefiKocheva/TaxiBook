using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace TaxiBook.Areas.Manager.Controllers
{
    [Authorize]
    [Area("Manager")]
    public class TaxiDriversController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> All()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            return View();
        }

        [HttpPut]
        public async Task<IActionResult> Update(string id)
        {
            return View();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            return View();
        }
    }
}
