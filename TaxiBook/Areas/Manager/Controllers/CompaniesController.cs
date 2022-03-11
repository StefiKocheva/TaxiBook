namespace TaxiBook.Areas.Manager.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = "Manager")]
    [Area("Manager")]
    public class CompaniesController : Controller
    {
        public IActionResult Overview()
        {
            return this.View();
        }
    }
}
