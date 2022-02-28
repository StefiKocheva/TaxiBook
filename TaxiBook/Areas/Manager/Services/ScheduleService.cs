namespace TaxiBook.Areas.Manager.Services
{
    using System;
    using System.Threading.Tasks;
    using Data.Models;
    using Services.Interfaces;
    using Data;
    using System.Collections.Generic;
    using TaxiBook.Areas.Manager.ViewModels.Schedule;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;

    public class ScheduleService : IScheduleService
    {
        private readonly TaxiBookDbContext db;

        public ScheduleService(TaxiBookDbContext db) => this.db = db;

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

        public async void DeleteEmployeeAsync(string id, string userId)
        {
            // var user = await this.ByIdAndByUserId(id, userId);
            // //if (favoriteCompany == null)
            // //{
            // //    Is it necessary to check if it's null?
            // //}
            // 
            // this.db.Users.Remove(user);
            // 
            // await this.db.SaveChangesAsync();
        }

        public async Task<IEnumerable<EmployeeListingViewModel>> All()
            => await this.db.Schedules.Select(s => new EmployeeListingViewModel()
            {
                Id = s.Id,
                FullName = s.Employee.FirstName + " " + s.Employee.LastName,
                //Role = s.Employee.Role

            })//.OrderByDescending(s => s.AddedOn)
            .ToListAsync();
    }
}
