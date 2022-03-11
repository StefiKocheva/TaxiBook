namespace TaxiBook.Services.ViewModels.Companies
{
    using System.ComponentModel.DataAnnotations;

    using static Vallidation.CreateCompanyViewModel;

    public class CreateCompanyViewModel
    {
        [Required(ErrorMessage = RequiredErrorMessage)]
        [StringLength(
            MaxNameLength, 
            ErrorMessage = CompanyNameLengthErrorMessage, 
            MinimumLength = MinNameLength)]
        public string Name { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        [StringLength(
            MaxDescriptionLength,
            ErrorMessage = DescriptionLengthErrorMessage,
            MinimumLength = MinDescriptionLength)]
        public string Description { get; set; }

        //[Required(ErrorMessage = RequiredErrorMessage)]
        //public IFormFile License { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        public string Province { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        public decimal? OneКilometerМileageDailyPrice { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        public decimal? OneКilometerМileageNightPrice { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        public decimal? DailyPricePerCall { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        public decimal? NightPricePerCall { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        public decimal? InitialDailyFee { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        public decimal? InitialNightFee { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        public decimal? DailyPricePerMinuteStay { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        public decimal? NightPricePerMinuteStay { get; set; }
    }
}
