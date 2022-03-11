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

        public EmployeeService(
            UserManager<ApplicationUser> userManager, 
            TaxiBookDbContext db)
        {
            this.userManager = userManager;
            this.db = db;
        }

        public IEnumerable<EmployeeDetailsViewModel> All()
            => this.db
                .Users
                .OrderBy(u => u.CreatedOn)
                .Select(u => new EmployeeDetailsViewModel()
                {
                    Id = u.Id,
                    FullName = u.FirstName + " " + u.LastName,
                    EmployeeType = u.EmployeeType,
                })
                .ToHashSet();

        public async Task<string> CreateAsync(
            string firstName, 
            string lastName, 
            string email, 
            string phoneNumber,
            EmployeeType employeeType,
            string numberPlate,
            string brand,
            string model)
        {

            var user = new ApplicationUser
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                PhoneNumber = phoneNumber,
                EmployeeType = employeeType,
                PasswordHash = "Employee_123",
                SecurityStamp = Guid.NewGuid().ToString(),
            };

            await this.db.AddAsync(user);

            await this.db.SaveChangesAsync();

            var password = "Employee_123";
            await this.userManager.CreateAsync(user, "Employee_123");

            await this.db.SaveChangesAsync();

            if (numberPlate != null && brand != null && model != null)
            {
                var taxi = new Taxi()
                {
                    NumberPlate = numberPlate,
                    Model = model,
                    Brand = brand,
                };

                await this.db.AddAsync(taxi);

                await this.db.SaveChangesAsync();
            }

            await this.AddToRoleAsync(user);

            return user.Id;
        }

        private async Task AddToRoleAsync(ApplicationUser user)
        {
            var employeeType = user.EmployeeType.ToString();

            _ = employeeType == "TaxiDriver" ? 
                await this.userManager.AddToRoleAsync(user, "TaxiDriver") 
                : await this.userManager.AddToRoleAsync(user, "Dispatcher");

            await this.db.SaveChangesAsync();
        }

        public async void DeleteAsync(string id)
        {
            var employee = await this.db.Users.FindAsync(id);

            this.db.Users.Remove(employee);

            await this.db.SaveChangesAsync();
        }
        
        public async Task<string> UpdateAsync(
            string id, 
            string firstName, 
            string lastName, 
            string email, 
            string phoneNumber//,
            //string brand,
            //string model,
            /*string numberPlate*/)
        {
            var user = await this.ByIdAndByUserId(id);

            //if (order == null)
            //{
            //    return "";
            //}

            user.FirstName = firstName;
            user.LastName = lastName;
            user.Email = email;
            user.PhoneNumber = phoneNumber;

            await this.db.SaveChangesAsync();

            return user.Id;
        }

        private async Task<ApplicationUser?> ByIdAndByUserId(string id)
        {
            var employee = await this.db.Users.FindAsync(id);

            return employee;
        }
    }
}
