namespace TaxiBook.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = "Client,TaxiDriver,Dispatcher,Manager")]
    public class ProfileController : Controller
    {
        [HttpGet]
        public IActionResult Overview(string userId)
        {
            return this.View();
        }

        [HttpPut]
        public IActionResult Update(string userId)
        {
            return this.Ok();
        }
    }
}
