namespace TaxiBook.Services.ViewModels.Profiles
{
    using System.Collections.Generic;

    public class ProfileListingViewModel
    {
        public IEnumerable<ProfileDetailsViewModel> Profiles { get; set; }
    }
}
