namespace TaxiBook.Services.Interfaces
{
    using System.Threading.Tasks;
    using Models.Companies;

    public interface ICompanyService
    {
        Task<string> CreateAsync(CreateCompanyViewModel model);
    }
}
