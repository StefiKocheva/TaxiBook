namespace TaxiBook.Areas.Manager.Services.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using ViewModels.Schedule;

    public interface IScheduleService
    {
        Task<string> AddEmployeeAsync(
            string email, 
            string role,
            string from, 
            string till);

        void DeleteEmployeeAsync(string id, string userId);

        Task<IEnumerable<EmployeeListingViewModel>> All();
    }
}
