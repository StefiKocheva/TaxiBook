namespace TaxiBook.Areas.Manager.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Data;
    using Data.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Services.Inerfaces;
    using TaxiBook.Areas.Manager.ViewModels.Employees;

    public class EmployeeService : IEmployeeService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly TaxiBookDbContext db;

        public EmployeeService(UserManager<ApplicationUser> userManager, TaxiBookDbContext db)
        {
            this._userManager = userManager;
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
                    //Role = u.Role
                })
                .ToHashSet();

        public async Task<string> CreateAsync(
            string firstName, 
            string lastName, 
            string email, 
            string phoneNumber,
            string numberPlate,
            string brand,
            string model)
        {
            var taxi = new Taxi()
            {
                NumberPlate = numberPlate,
                Model = model,
                Brand = brand,
            };

            await this.db.AddAsync(taxi);

            await this.db.SaveChangesAsync();

            var user = new ApplicationUser
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                PhoneNumber = phoneNumber
            };

            await this._userManager.CreateAsync(user, "Employee_123");

            await this.db.SaveChangesAsync();

            return user.Id;
        }

        public async void DeleteAsync(string id)
        {
            var employee = await this.ByIdAndByUserId(id);
            //if (favoriteCompany == null)
            //{
            //    Is it necessary to check if it's null?
            //}

            this.db.Users.Remove(employee);

            await this.db.SaveChangesAsync();
        }
        
        public async void UpdateAsync(
            string id, 
            string firstName, 
            string lastName, 
            string placeOfResidence, 
            string email, 
            string phoneNumber)
        {
            var user = await this.ByIdAndByUserId(id);

            //if (order == null)
            //{
            //    return "";
            //}

            user.FirstName = firstName;
            user.LastName = lastName;
            //user.Address.PlaceOfResidence = placeOfResidence;
            user.Email = email;
            user.PhoneNumber = phoneNumber;

            await this.db.SaveChangesAsync();
        }

        private async Task<ApplicationUser?> ByIdAndByUserId(string id)
           => await this.db
               .Users
               .Where(u => u.Id == id)
               .FirstOrDefaultAsync();
    }
}
