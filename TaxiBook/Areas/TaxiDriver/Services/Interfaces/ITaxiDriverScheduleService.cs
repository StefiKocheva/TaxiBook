namespace TaxiBook.Areas.TaxiDriver.Services.Inerfaces
{
    using System;
    using System.Threading.Tasks;

    public interface ITaxiDriverScheduleService
    {
        Task<string> ForthcomingАbsenceAsync(DateTime from, DateTime till);

        Task<string> AddEmployeeAsync(string firstName, string lastName, string role, string from, string till);
    }
}
