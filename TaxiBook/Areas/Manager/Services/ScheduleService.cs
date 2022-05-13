namespace TaxiBook.Areas.Manager.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Data;
    using Data.Models;
    using Infrastructure.Services;
    using Microsoft.EntityFrameworkCore;
    using Services.Interfaces;
    using ViewModels.Schedule;

    public class ScheduleService : IScheduleService
    {
        private readonly TaxiBookDbContext db;
        private readonly ICurrentUserService currentUserService;

        public ScheduleService(
            TaxiBookDbContext db, 
            ICurrentUserService currentUserService)
        {
            this.db = db;
            this.currentUserService = currentUserService;
        }

        public async Task<string> AddEmployeeAsync(
            string from, 
            string till, 
            string name,
            string email)
        {
            var employee = this.db
                .Users
                .Where(u => u.Email == email)
                .FirstOrDefault();

            var company = this.currentUserService.GetUser().Company;

            var workTime = new WorkTime
            {
                Day = 14,
                Month = 5,
                Year = 2022,
                From = from,
                Till = till,
                Employee = employee,
                EmployeeId = employee.Id,
                Company = company,
                Companyid = company.Id,
            };

            await this.db.WorkTimes.AddAsync(workTime);
             
            await this.db.SaveChangesAsync();

            return workTime.Id;
        }

        public async void ApproveAbsenceAsync(string id)
        {
            var absence = await this.db
                .Absences
                .FirstOrDefaultAsync(a => a.Id == id);

            absence.IsApproved = true;

            await this.db.SaveChangesAsync();
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

        public async void DisapproveAbsenceAsync(string id)
        {
            var absence = await this.db
                .Absences
                .FirstOrDefaultAsync(a => a.Id == id);

            this.db.Remove(absence);

            await this.db.SaveChangesAsync();
        }

        //public IEnumerable<EmployeeDetailsViewModel> GetAllEmployeesForToday()
        //{
        //    this.db.WorkTimes
        //        .Where(w => w.Company == this.currentUserService.GetUser().Company)
        //        .Where
        //}

        public IEnumerable<AbsenceDetailsViewModel> ShowAllRequestsForAbsences()
            => this.db
            .Absences
            .Where(a => a.CompanyId == this.currentUserService.GetUser().CompanyId)
            .Select(a => new AbsenceDetailsViewModel()
            {
                Id = a.Id,
                FullName = a.Employee.FirstName + " " + a.Employee.LastName,
                Role = a.Employee.EmployeeRole,
                From = a.From,
                Till = a.Till,
            })
            .ToHashSet();
    }
}
