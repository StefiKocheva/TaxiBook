namespace TaxiBook.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class ProfileController : Controller
    {
        [HttpGet]
        public IActionResult Overview()
        {
            return this.View();
        }

        [HttpGet]
        public IActionResult Edit()
        {
            return this.View();
        }
    }
}
