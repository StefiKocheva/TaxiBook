namespace TaxiBook.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class ProfileController : Controller
    {
        [HttpGet]
        public IActionResult Overview(string userId)
        {
            return this.View();
        }

        [HttpGet]
        public IActionResult Edit(string userId)
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
