namespace TaxiBook.Services.Interfaces
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using ViewModels.Profiles;

    public interface IProfileService
    {
        Task<ProfileInformationViewModel> OverviewAsync();

        Task ChangeProfilePictureAsync(IFormFile profilePicture);

        Task EditAsync(
            string firstName, string lastName, string email, string phoneNumber);
    }
}
