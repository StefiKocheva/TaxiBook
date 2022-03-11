namespace TaxiBook.Areas.Manager.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Data;
    using Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Services.Interfaces;
    using ViewModels.Schedule;

    public class ScheduleService : IScheduleService
    {
        private readonly TaxiBookDbContext db;

        public ScheduleService(TaxiBookDbContext db) 
            => this.db = db;

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
