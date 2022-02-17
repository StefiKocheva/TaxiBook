namespace TaxiBook.Services.Interfaces
{
    using System.Threading.Tasks;
    using ViewModels.Companies;

    public interface ICompanyService
    {
        Task<string> CreateAsync(CreateCompanyViewModel model);
    }
}
