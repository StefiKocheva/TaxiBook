namespace TaxiBook.Infrastructure.Services
{
    using TaxiBook.Data.Models;

    public interface ICurrentUserService
    {
        string GetId();

        string GetUserName();

        ApplicationUser GetUser();
    }
}
