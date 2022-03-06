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
        private readonly IEmployeeService employeeService;

        public EmployeesController(IEmployeeService employeeService) => this.employeeService = employeeService;

        [HttpGet]
        public IActionResult All()
        {
            var model = new EmployeeListingViewModel();

            model.Employees = this.employeeService.All();

            return this.View(model);
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

            var userId = await this.employeeService.CreateAsync(
                model.FirstName,
                model.LastName,
                model.Email,
                model.PhoneNumber,
                model.NumberPlate,
                model.Brand,
                model.Model);

            return this.RedirectToAction("All");
        }

        [HttpGet]
        public IActionResult Edit(string userId)
        {
            return this.View();
        }
    }
}
