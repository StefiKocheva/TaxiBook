namespace TaxiBook.Areas.Manager.Services
{
    using System.Threading.Tasks;
    using Data.Models;

    public class ScheduleService : IScheduleService
    {
        public async Task<string> AddEmployeeAsync(string firstName, string lastName, string role, string from, string till)
        {
            var user = new ApplicationUser
            {
                // TODO
            };

            return user.Id;
        }
    }
}
