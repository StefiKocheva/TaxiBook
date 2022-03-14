using TaxiBook.Data.Models;

namespace TaxiBook.Infrastructure.Services
{
    public interface ICurrentUserService
    {
        string GetId();

        string GetUserName();

        ApplicationUser GetUser();
    }
}
