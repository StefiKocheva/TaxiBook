using Microsoft.AspNetCore.Http;

namespace TaxiBook.Services.ViewModels.Profiles
{
    public class UpdateProfileViewModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public IFormFile ProfilePicture { get; set; }
    }
}
