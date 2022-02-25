namespace TaxiBook.Areas.Dispatcher.Services.Interfaces
{
    using System;
    using System.Threading.Tasks;

    public interface IScheduleService
    {
        Task<string> CreateАbsenceAsync(
            DateTime from, 
            DateTime till);

        Task<string> AddEmployeeAsync(
            string firstName, 
            string lastName, 
            string role, 
            string from, 
            string till);
    }
}
