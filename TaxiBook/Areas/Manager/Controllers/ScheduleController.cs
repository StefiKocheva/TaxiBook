namespace TaxiBook.Areas.Manager.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class ScheduleController : Controller
    {
        [HttpGet]
        public IActionResult CurrentMonth()
        {
            return View();
        }

        [HttpGet]
        public IActionResult DayDetails()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddEmployee()
        {
            return View();
        }
    }
}
