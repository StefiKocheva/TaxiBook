namespace TaxiBook.ViewModels.Companies
{
    using Microsoft.AspNetCore.Http;

    public class CreateCompanyViewModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public IFormFile License { get; set; }
    }
}
