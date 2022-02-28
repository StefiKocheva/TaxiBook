namespace TaxiBook.Areas.Manager.Services
{
    using System.Linq;
    using System.Threading.Tasks;
    using Data;
    using Data.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Services.Inerfaces;

    public class EmployeeService : IEmployeeService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly TaxiBookDbContext db;

        public EmployeeService(UserManager<ApplicationUser> userManager, TaxiBookDbContext db)
        {
            this._userManager = userManager;
            this.db = db;
        }

        public async Task<string> CreateAsync(
            string firstName, 
            string lastName, 
            string placeOfResidence, 
            string email, 
            string phoneNumber)
        {
            var user = new ApplicationUser
            {
                FirstName = firstName,
                // Address.PlaceOfResidence = placeOfResidence,
                LastName = lastName,
                Email = email,
                PhoneNumber = phoneNumber
            };

            await this._userManager.CreateAsync(user, "Employee_123");

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
            user.Address.PlaceOfResidence = placeOfResidence;
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
