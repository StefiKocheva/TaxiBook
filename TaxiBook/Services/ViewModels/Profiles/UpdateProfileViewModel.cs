namespace TaxiBook.Services.ViewModels.Profiles
{
    using System.ComponentModel.DataAnnotations;

    using static Vallidation.UpdateProfileViewModel;

    public class UpdateProfileViewModel
    {
        //[Required(ErrorMessage = RequiredErrorMessage)]
        public string FirstName { get; set; }

        //[Required(ErrorMessage = RequiredErrorMessage)]
        public string LastName { get; set; }

        //[Required(ErrorMessage = RequiredErrorMessage)]
        public string Email { get; set; }

        //[Required(ErrorMessage = RequiredErrorMessage)]
        public string PhoneNumber { get; set; }
    }
}
