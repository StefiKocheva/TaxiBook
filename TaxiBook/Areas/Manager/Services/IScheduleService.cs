namespace TaxiBook.Areas.Manager.Services
{
    using System.Threading.Tasks;

    public interface IScheduleService
    {
        Task<string> AddEmployeeAsync(string firstName, string lastName, string role, string from, string till);
    }
}
