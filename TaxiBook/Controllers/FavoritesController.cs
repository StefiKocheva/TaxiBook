namespace TaxiBook.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Services.Interfaces;
    using Services.ViewModels.Favorites;
    using TaxiBook.Infrastructure.Services;

    [Authorize(Roles = "Client")]
    public class FavoritesController : Controller
    {
        private readonly IFavoriteService favoriteService;
        private readonly ICurrentUserService currentUserService;

        public FavoritesController(IFavoriteService favoriteService, ICurrentUserService currentUserService)
        {
            this.favoriteService = favoriteService;
            this.currentUserService = currentUserService;
        }

        [HttpGet]
        public IActionResult All()
        {
            var viewModel = new ListingViewModel
            {
                AllCompanies = this.favoriteService.OverviewCompanies(),
                FavoriteCompanies = this.favoriteService.OverviewFavoriteCompanies(),
            };

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> All(ListingViewModel viewModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(viewModel);
            }

            await this.favoriteService
                .AddAsync(viewModel.CreateFavoriteViewModel.CompanyName);

            return this.RedirectToAction("All");
        }

        [HttpPut]
        public IActionResult Update()
        {
            return this.Ok();
        }

        [HttpDelete]
        public IActionResult All(string id)
        {
            this.favoriteService
                .DeleteAsync(id, this.currentUserService.GetId());

            return this.RedirectToAction("All");
        }
    }
}
