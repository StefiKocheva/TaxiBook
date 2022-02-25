namespace TaxiBook.Areas.Manager.Services.Interfaces
{
    using System.Threading.Tasks;

    public interface IScheduleService
    {
        Task<string> AddEmployeeAsync(
            string email, 
            string role,
            string from, 
            string till);

        void DeleteEmployeeAsync(string id);
    }
}
