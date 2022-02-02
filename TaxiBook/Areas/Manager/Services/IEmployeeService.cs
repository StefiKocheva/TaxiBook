using System.Threading.Tasks;

namespace TaxiBook.Areas.Manager.Services
{
    public interface IEmployeeService
    {
        Task<string> CreateAsync(string firstName, string lastName, string email, string phoneNumber);
    }
}
