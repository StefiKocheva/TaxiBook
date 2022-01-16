namespace TaxiBook.Areas.Manager.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using TaxiBook.Areas.Manager.ViewModels.Schedule;

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
