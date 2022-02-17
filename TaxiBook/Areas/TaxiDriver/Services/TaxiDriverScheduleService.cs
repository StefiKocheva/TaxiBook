namespace TaxiBook.Areas.TaxiDriver.Services
{
    using System;
    using System.Threading.Tasks;
    using Data;
    using Data.Models;
    using Services.Inerfaces;

    public class TaxiDriverScheduleService : ITaxiDriverScheduleService
    {
        private readonly TaxiBookDbContext db;

        public TaxiDriverScheduleService(TaxiBookDbContext db)
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

        public async Task<string> AddEmployeeAsync(string firstName, string lastName, string role, string from, string till)
        {
            var user = new ApplicationUser
            {
                FirstName = firstName,
                LastName = lastName,
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
