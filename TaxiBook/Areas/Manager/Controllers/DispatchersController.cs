using Microsoft.AspNetCore.Identity;
using TaxiBook.Areas.Manager.Services;
using TaxiBook.Areas.Manager.ViewModels.Dispatchers;
using TaxiBook.Data;
using TaxiBook.Data.Models;

namespace TaxiBook.Areas.Manager.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    [Authorize]
    [Area("Manager")]
    public class DispatchersController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public DispatchersController(IEmployeeService employeeService)
        {
            this._employeeService = employeeService;
        }

        [HttpGet]
        public IActionResult All()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest();
            }

            var userId = await this._employeeService.CreateAsync(
                model.FirstName,
                model.LastName,
                model.Email,
                model.PhoneNumber);

            return this.RedirectPermanent("Manager/Dispatchers/All");
        }

        [HttpGet]
        public IActionResult Edit()
        {
            return View();
        }
    }
}
