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

        public EmployeesController(IEmployeeService employeeService)
            => this.employeeService = employeeService;

        [HttpGet]
        public IActionResult All()
        {
            var model = new EmployeeListingViewModel
            {
                Employees = this.employeeService.All()
            };

            return this.View(model);
        }

        [HttpGet]
        public IActionResult Create()
            => this.View();

        [HttpPost]
        public async Task<IActionResult> Create(CreateViewModel viewModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest();
            }

            _ = await this.employeeService.CreateAsync(
                viewModel.FirstName,
                viewModel.LastName,
                viewModel.Email,
                viewModel.PhoneNumber,
                viewModel.EmployeeType,
                viewModel.NumberPlate,
                viewModel.Brand,
                viewModel.Model);

            return this.RedirectToAction("All");
        }

        [HttpGet]
        public IActionResult Overview(string userId)
        {
            return this.View();
        }

        [HttpPut]
        public  async Task Update(string id, UpdateEmployeeViewModel viewModel)
        {
            // TODO
        }
    }
}
