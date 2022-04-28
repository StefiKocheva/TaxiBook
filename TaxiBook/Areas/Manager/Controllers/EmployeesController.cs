namespace TaxiBook.Areas.Manager.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Services.Inerfaces;
    using ViewModels.Employees;

    [Authorize(Roles = "Manager")]
    [Area("Manager")]
    public class EmployeesController : Controller
    {
        private readonly IEmployeeService employeeService;

        public EmployeesController(IEmployeeService employeeService)
            => this.employeeService = employeeService;

        [HttpGet]
        public IActionResult All()
        {
            var viewModel = new EmployeeListingViewModel
            {
                Employees = this.employeeService.All()
            };

            return this.View(viewModel);
        }

        [HttpGet]
        public IActionResult Create()
            => this.View();

        [HttpPost]
        public async Task<IActionResult> Create(CreateViewModel viewModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(viewModel);
            }

            await this.employeeService.CreateAsync(
                viewModel.FirstName,
                viewModel.LastName,
                viewModel.Email,
                viewModel.PhoneNumber,
                viewModel.EmployeeRole,
                viewModel.NumberPlate,
                viewModel.Brand,
                viewModel.Model);

            return this.RedirectToAction("All");
        }

        [HttpGet]
        public IActionResult Overview()
        {
            //var viewModel = new EmployeeListingViewModel
            //{
            //    Employees = this.employeeService.Details(id)
            //};

            return this.View();
        }

        [HttpGet]
        public IActionResult Edit()
        {
            return this.View();
        }

        [HttpPut]
        public async Task<IActionResult> Update(
            string id, 
            UpdateEmployeeViewModel viewModel)
        {
            await this.employeeService.UpdateAsync(
                id, 
                viewModel.FirstName, 
                viewModel.LastName, 
                viewModel.Email, 
                viewModel.PhoneNumber,
                viewModel.Brand,
                viewModel.Model,
                viewModel.NumberPlate);

            return this.RedirectToAction("All");
        }

        [HttpDelete]
        public IActionResult Delete(string id)
        {
            if (!this.ModelState.IsValid)
            {
                return this.Ok();
            }

            this.employeeService.DeleteAsync(id);

            return this.RedirectToAction("All");
        }
    }
}
