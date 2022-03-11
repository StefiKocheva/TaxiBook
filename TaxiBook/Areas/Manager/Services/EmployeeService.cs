namespace TaxiBook.Areas.Manager.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Data;
    using Data.Models;
    using Data.Models.Enums;
    using Inerfaces;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using ViewModels.Employees;

    public class EmployeeService : IEmployeeService
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly TaxiBookDbContext db;
        private readonly SignInManager<ApplicationUser> signInManager;

        public EmployeeService(
            UserManager<ApplicationUser> userManager, 
            TaxiBookDbContext db,
            SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;

            this.db = db;
            this.signInManager = signInManager;
        }

        public IEnumerable<EmployeeDetailsViewModel> All()
            => this.db
                .Users
                .OrderByDescending(u => u.CreatedOn)
                .Select(u => new EmployeeDetailsViewModel()
                {
                    Id = u.Id,
                    FullName = u.FirstName + " " + u.LastName,
                    EmployeeRole = u.EmployeeRole,
                })
                .ToHashSet();

        public async Task<string> CreateAsync(
            string firstName, 
            string lastName, 
            string email, 
            string phoneNumber,
            EmployeeRole employeeRole,
            string numberPlate,
            string brand,
            string model)
        {

            var employee = new ApplicationUser
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                UserName = email,
                PhoneNumber = phoneNumber,
                EmailConfirmed = true,
                ImageUrl = null,
                EmployeeRole = employeeRole,
            };

            var password = "Employee_123";
            await this.userManager.CreateAsync(employee, password);
            await this.userManager.AddToRoleAsync(employee, employeeRole.ToString());

            if (numberPlate != null && brand != null && model != null)
            {
                var taxi = new Taxi()
                {
                    NumberPlate = numberPlate,
                    Model = model,
                    Brand = brand,
                    DriverId = employee.Id,
                };

                await this.db.AddAsync(taxi);

                await this.db.SaveChangesAsync();
            }

            return employee.Id;
        }

        public async void DeleteAsync(string id)
        {
            var employee = await this.db.Users.FindAsync(id);

            this.db.Users.Remove(employee);

            await this.db.SaveChangesAsync();
        }

        //public IEnumerable<EmployeeDetailsViewModel> Details(string id)
        //    => this.db
        //    .Users
        //    .Where(u => u.Id == id)
        //    .Select(u => new EmployeeDetailsViewModel()
        //    {
        //        FirstName = u.FirstName,
        //        LastName = u.LastName,
        //        Email = u.Email,
        //        PhoneNumber = u.PhoneNumber,
        //        NumberPlate = this.db.Taxies.Where(t => t.DriverId == id).Select(t => t.NumberPlate).ToString(),
        //        Brand = this.db.Taxies.Where(t => t.DriverId == id).Select(t => t.Brand).ToString(),
        //        Model = this.db.Taxies.Where(t => t.DriverId == id).Select(t => t.Model).ToString(),
        //    }).ToHashSet();

        public async Task<string> UpdateAsync(
            string id, 
            string firstName, 
            string lastName, 
            string email, 
            string phoneNumber,
            string brand,
            string model,
            string numberPlate)
        {
            var employee = await this.db.Users.FindAsync(id);

            employee.FirstName = firstName;
            employee.LastName = lastName;
            employee.Email = email;
            employee.PhoneNumber = phoneNumber;

            await this.db.SaveChangesAsync();

            return employee.Id;
        }

        //private async Task<ApplicationUser> ByIdAndByUserId(string id)
        //{
        //    var employee = await this.db.Users.FindAsync(id);

        //    return employee;
        //}
    }
}
