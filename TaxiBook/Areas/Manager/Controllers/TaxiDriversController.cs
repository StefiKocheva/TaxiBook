namespace TaxiBook.Areas.Manager.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    [Area("Manager")]
    public class TaxiDriversController : Controller
    {
        [HttpGet]
        public IActionResult All()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Edit(string id)
        {
            return View();
        }

        [HttpPut]
        public IActionResult Update(string id)
        {
            return View();
        }

        [HttpDelete]
        public IActionResult Delete(string id)
        {
            return View();
        }
    }
}
