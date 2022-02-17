namespace TaxiBook.Areas.Dispatcher.Services.Interfaces
{
    using System;
    using System.Threading.Tasks;

    public interface IDispatcherScheduleService
    {
        Task<string> ForthcomingАbsenceAsync(DateTime from, DateTime till);

        Task<string> AddEmployeeAsync(string firstName, string lastName, string role, string from, string till);
    }
}
