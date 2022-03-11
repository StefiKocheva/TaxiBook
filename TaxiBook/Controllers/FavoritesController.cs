namespace TaxiBook.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Services.Interfaces;
    using Services.ViewModels.Favorites;

    [Authorize(Roles = "Client")]
    public class FavoritesController : Controller
    {
        private readonly IFavoriteService favoriteService;

        public FavoritesController(IFavoriteService favoriteService) 
            => this.favoriteService = favoriteService;

        [HttpGet]
        public IActionResult All()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCompany(CreateFavoriteViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return this.View(viewModel);
            }

            var favoriteId = await this.favoriteService.AddAsync(viewModel.CompanyName);

            return this.RedirectToAction("All");
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
