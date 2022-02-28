namespace TaxiBook.Areas.Manager.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Services.Inerfaces;
    using ViewModels.Employees;

    [Authorize]
    [Area("Manager")]
    public class EmployeesController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService) => this._employeeService = employeeService;

        [HttpGet]
        public IActionResult All()
        {
            return this.View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest();
            }

            var userId = await this._employeeService.CreateAsync(
                model.FirstName,
                model.LastName,
                model.PlaceOfResidence,
                model.Email,
                model.PhoneNumber);

            return this.RedirectPermanent("All");
        }

        [HttpGet]
        public IActionResult Edit(string userId)
        {
            return this.View();
        }
    }
}
