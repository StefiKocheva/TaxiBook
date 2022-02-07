namespace TaxiBook.Services.Models.Companies
{
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNetCore.Http;

    public class CreateCompanyViewModel
    {
        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string Name { get; set; }

        // public string Description { get; set; }

        [Required]
        public decimal DailyТariff { get; set; }

        [Required]
        public decimal NightТariff { get; set; }

        public string Address { get; set; } // ?

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public IFormFile License { get; set; }
    }
}
