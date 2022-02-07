namespace TaxiBook.Areas.Manager.Services
{
    using System.Threading.Tasks;

    public interface IEmployeeService
    {
        Task<string> CreateAsync(string firstName, string lastName, string email, string phoneNumber);
    }
}
