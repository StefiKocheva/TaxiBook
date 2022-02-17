namespace TaxiBook.Services.Interfaces
{
    using System.Threading.Tasks;

    public interface IFavoriteService
    {
        Task<string> CreateAsync(string companyName);
    }
}
