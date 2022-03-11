namespace TaxiBook.Areas.Manager.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Services.Interfaces;
    using ViewModels.Schedule;

    [Authorize(Roles = "Manager")]
    [Area("Manager")]
    public class ScheduleController : Controller
    {
        private readonly IScheduleService _scheduleService;

        public ScheduleController(IScheduleService scheduleService) 
            => this._scheduleService = scheduleService;

        [HttpGet]
        public IActionResult CurrentMonth()
        {
            return this.View();
        }

        [HttpGet]
        public IActionResult Employees()
        {
            return this.View();
        }

        [HttpGet]
        public IActionResult AddEmployee()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee(AddEmployeeViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest();
            }

            var userId = await this._scheduleService.AddEmployeeAsync(
                model.Email,
                model.Role,
                model.From,
                model.Till);

            return this.RedirectPermanent("Employees");
        }
    }
}
