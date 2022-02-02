using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using TaxiBook.Data.Models;

namespace TaxiBook.Areas.Manager.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public EmployeeService(UserManager<ApplicationUser> userManager)
        {
            this._userManager = userManager;
        }

        public async Task<string> CreateAsync(string firstName, string lastName, string email, string phoneNumber)
        {
            var user = new ApplicationUser
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                PhoneNumber = phoneNumber
            };

            await this._userManager.CreateAsync(user, "Employee_123");

            return user.Id;
        }
    }
}
