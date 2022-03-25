namespace TaxiBook.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using TaxiBook.Services.Interfaces;
    using TaxiBook.Services.ViewModels.Profiles;

    [Authorize(Roles = "Client,TaxiDriver,Dispatcher,Manager")]
    public class ProfilesController : Controller
    {
        private readonly IProfileService profileService;

        public ProfilesController(IProfileService profileService) 
            => this.profileService = profileService;

        [HttpGet]
        public IActionResult Overview()
        {
            var viewModel = new ProfileListingViewModel()
            {
                Profiles = this.profileService.Overview()
            };

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateProfileViewModel viewModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View("Overview", viewModel);
            }

            await this.profileService.UpdateAsync(
                viewModel.FirstName,
                viewModel.LastName,
                viewModel.Email,
                viewModel.PhoneNumber);

            return this.RedirectToAction("Overview");
        }
    }
}
