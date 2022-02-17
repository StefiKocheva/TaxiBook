namespace TaxiBook.Areas.Manager.ViewModels.Employees
{
    using System.ComponentModel.DataAnnotations;

    using static Vallidation.CreateViewModel;

    public class CreateViewModel
    {
        [Required(ErrorMessage = RequiredErrorMessage)]
        [StringLength(MaxNameLength, ErrorMessage = StringLengthErrorMessage, MinimumLength = MinNameLength)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        [StringLength(MaxNameLength, ErrorMessage = StringLengthErrorMessage, MinimumLength = MinNameLength)]
        public string LastName { get; set; }

        public string PlaceOfResidence { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        public string Email { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        [Phone]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        [MaxLength(MaxBrandAndModelLength)]
        public string BrandAndModel { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        [Range(MinNumberPlateLength, MaxNumberPlateLength)]
        public string NumberPlate { get; set; }
    }
}
