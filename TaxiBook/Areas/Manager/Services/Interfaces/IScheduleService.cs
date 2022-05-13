namespace TaxiBook.Areas.Manager.Services.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using ViewModels.Schedule;

    public interface IScheduleService
    {
        Task<string> AddEmployeeAsync(
            string from, 
            string till,
            string name, 
            string email);

        //IEnumerable<EmployeeDetailsViewModel> GetAllEmployeesForToday();

        void DeleteEmployeeAsync(string id, string userId);

        IEnumerable<AbsenceDetailsViewModel> ShowAllRequestsForAbsences();

        void ApproveAbsenceAsync(string id);

        void DisapproveAbsenceAsync(string id);
    }
}
