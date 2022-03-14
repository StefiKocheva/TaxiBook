namespace TaxiBook.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
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

        [HttpPut]
        public IActionResult Update(string userId)
        {
            return this.Ok();
        }
    }
}
