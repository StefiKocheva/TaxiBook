namespace TaxiBook.Services.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using ViewModels.Profiles;

    public interface IProfileService
    {
        IEnumerable<ProfileDetailsViewModel> Overview();

        Task UpdateAsync(
            string firstName,
            string lastName,
            string email,
            string phoneNumber);
    }
}
