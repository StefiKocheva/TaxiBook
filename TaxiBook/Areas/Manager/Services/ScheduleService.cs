namespace TaxiBook.Areas.Manager.Services
{
    using System;
    using System.Threading.Tasks;
    using Data.Models;
    using Services.Interfaces;
    using TaxiBook.Data;

    public class ScheduleService : IScheduleService
    {
        private readonly TaxiBookDbContext db;

        public ScheduleService(TaxiBookDbContext db)
        {
            this.db = db;
        }

        public async Task<string> ForthcomingАbsenceAsync(DateTime from, DateTime till)
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

        public async Task<string> AddEmployeeAsync(string email, string role, string from, string till)
        {
            var user = new ApplicationUser
            {
                Email = email,
                // Role -> Manager, Dispatcher, TaxiDriver, Client
                // From = from,
                // Till = till,
            };

            await db.Users.AddAsync(user);

            await db.SaveChangesAsync();

            return user.Id;
        }
    }
}
