namespace TaxiBook.Services.Interfaces
{
    using System.Collections.Generic;
    using ViewModels.Profiles;

    public interface IProfileService
    {
        IEnumerable<ProfileDetailsViewModel> Overview();
    }
}
