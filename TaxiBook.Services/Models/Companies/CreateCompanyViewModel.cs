using Microsoft.AspNetCore.Http;

namespace TaxiBook.Services.Models.Companies
{
    public class CreateCompanyViewModel
    {
        public string Name { get; set; }

        // public string Description { get; set; }

        public decimal DailyТariff { get; set; }

        public decimal NightТariff { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public IFormFile License { get; set; }
    }
}
