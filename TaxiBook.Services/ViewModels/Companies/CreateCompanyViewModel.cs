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

        public string Address { get; set; } // ? Description

        [Required(ErrorMessage = RequiredErrorMessage)]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        public IFormFile License { get; set; }
    }
}
