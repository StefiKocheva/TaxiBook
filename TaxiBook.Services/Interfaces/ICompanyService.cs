namespace TaxiBook.Services.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using ViewModels.Companies;

    public interface ICompanyService
    {
        IEnumerable<CompanyDetailsViewModel> All();

        Task<string> CreateAsync(
            string name, 
            decimal dailyTariff, 
            decimal nightTariff, 
            string phoneNumber,
            string description
           /* IFormFile license*/);
    }
}
