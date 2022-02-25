namespace TaxiBook.Services.Interfaces
{
    using System.Threading.Tasks;

    public interface IFavoriteService
    {
        Task<string> AddAsync(string companyName);

        void DeleteAsync(
            string id, 
            string userId);
    }
}
