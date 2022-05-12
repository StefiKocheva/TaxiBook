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
        private readonly IScheduleService scheduleService;

        public ScheduleController(IScheduleService scheduleService) 
            => this.scheduleService = scheduleService;

        [HttpGet]
        public IActionResult CurrentMonth()
        {
            var viewModel = new AbsenceListingViewModel()
            {
                Absences = this.scheduleService.ShowAllRequestsForAbsences(),
            };

            return this.View(viewModel);
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

            await this.scheduleService.AddEmployeeAsync(
                model.Email,
                model.Role,
                model.From,
                model.Till);

            return this.RedirectPermanent("Employees");
        }

        [HttpPost]
        public ActionResult ApproveAbsence(string id)
        {
            this.scheduleService.ApproveAbsenceAsync(id);

            return this.RedirectToActionPermanent("CurrentMonth");
        }

        [HttpPost]
        public ActionResult DisapproveAbsence(string id)
        {
            this.scheduleService.DisapproveAbsenceAsync(id);

            return this.RedirectToActionPermanent("CurrentMonth");
        }
    }
}
