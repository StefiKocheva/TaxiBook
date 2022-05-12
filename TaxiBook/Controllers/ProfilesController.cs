namespace TaxiBook.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Services.Interfaces;
    using Services.ViewModels.Profiles;

    [Authorize(Roles = "Client,TaxiDriver,Dispatcher,Manager")]
    public class ProfilesController : Controller
    {
        private readonly IProfileService profileService;

        public ProfilesController(IProfileService profileService)
            => this.profileService = profileService;

        [HttpGet]
        public async Task<IActionResult> Overview()
        {
            var viewModel = await this.profileService.OverviewAsync();

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProfileInformationViewModel viewModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View("Overview", viewModel);
            }

            await this.profileService.EditAsync(
                viewModel.UpdateProfileViewModel.FirstName, 
                viewModel.UpdateProfileViewModel.LastName, 
                viewModel.UpdateProfileViewModel.Email,
                viewModel.UpdateProfileViewModel.PhoneNumber);

            return this.RedirectToAction("Overview");
        }

        [HttpPost]
        public async Task<IActionResult> ChangeProfilePicture(ProfileInformationViewModel viewModel)
        {
            await this.profileService.ChangeProfilePictureAsync(viewModel.UpdateProfileViewModel.ProfilePicture);

            return this.RedirectToAction("Overview");
        }
    }
}
