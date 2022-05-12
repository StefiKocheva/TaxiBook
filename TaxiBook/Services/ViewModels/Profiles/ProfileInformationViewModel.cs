namespace TaxiBook.Services.ViewModels.Profiles
{
    public class ProfileInformationViewModel
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string ImageUrl { get; set; }

        public UpdateProfileViewModel UpdateProfileViewModel { get; set; }
    }
}
