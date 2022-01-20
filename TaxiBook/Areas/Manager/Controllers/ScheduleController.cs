namespace TaxiBook.Areas.Manager.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using TaxiBook.Areas.Manager.ViewModels.Schedule;

    [Authorize]
    [Area("Manager")]
    public class ScheduleController : Controller
    {
        [HttpGet]
        public IActionResult CurrentMonth()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Employees()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddEmployee()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddEmployee(AddEmployeeViewModel model)
        {
            return View();
        }
    }
}
