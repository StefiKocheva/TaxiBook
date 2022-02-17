namespace TaxiBook.Areas.Manager.Services.Interfaces
{
    using System;
    using System.Threading.Tasks;

    public interface IScheduleService
    {
        Task<string> ForthcomingАbsenceAsync(DateTime from, DateTime till);

        Task<string> AddEmployeeAsync(string email, string role, string from, string till);
    }
}
