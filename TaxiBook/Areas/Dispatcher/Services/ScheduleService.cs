namespace TaxiBook.Areas.Dispatcher.Services
{
    using System;
    using System.Threading.Tasks;
    using Data;
    using Data.Models;
    using Services.Interfaces;

    public class ScheduleService : IScheduleService
    {
        private readonly TaxiBookDbContext db;

        public ScheduleService(TaxiBookDbContext db)
        {
            this.db = db;
        }

        public async Task<string> AddEmployeeAsync(string firstName, string lastName, string role, string from, string till)
        {
            var user = new ApplicationUser
            {
                FirstName = firstName,
                LastName = lastName,
                // Role -> Dispatcher, TaxiDriver
                // From = from,
                // Till = till,
            };

            return user.Id;
        }

        public async Task<string> CreateАbsenceAsync(DateTime from, DateTime till)
        {
            var forthcomingАbsence = new Absence
            {
               // From = from,
               // Till = till,
            };

            await db.Absences.AddAsync(forthcomingАbsence);

            await db.SaveChangesAsync();

            return forthcomingАbsence.Id;
        }
    }
}
