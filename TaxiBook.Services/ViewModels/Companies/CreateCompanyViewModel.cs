namespace TaxiBook.Services.ViewModels.Companies
{
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Http;

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
        public decimal DailyТariff { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        public decimal NightТariff { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        [StringLength(
            MaxDescriptionLength, 
            ErrorMessage = DescriptionLengthErrorMessage, 
            MinimumLength = MinDescriptionLength)]
        public string Description { get; set; } 

        [Required(ErrorMessage = RequiredErrorMessage)]
        public string PhoneNumber { get; set; }

        //[Required(ErrorMessage = RequiredErrorMessage)]
        //public IFormFile License { get; set; }
    }
}
