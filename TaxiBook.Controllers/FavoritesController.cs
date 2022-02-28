namespace TaxiBook.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Services.Interfaces;
    using Services.ViewModels.Favorites;

    public class FavoritesController : Controller
    {
        private readonly IFavoriteService _service;

        public FavoritesController(IFavoriteService service) => this._service = service;

        [HttpGet]
        public IActionResult All()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCompany(CreateFavoriteViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.BadRequest();
            }

            var favoriteId = await this._service.AddAsync(model.CompanyName);

            return this.RedirectPermanent("Companies");
        }

        [HttpPut]
        public IActionResult Update()
        {
            return this.Ok();
        }

        [HttpDelete]
        public IActionResult Delete()
        {
            return this.Ok();
        }
    }
}
