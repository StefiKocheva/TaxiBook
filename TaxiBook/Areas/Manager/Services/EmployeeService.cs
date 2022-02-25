namespace TaxiBook.Areas.Manager.Services
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Identity;
    using Data.Models;
    using Services.Inerfaces;

    public class EmployeeService : IEmployeeService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public EmployeeService(UserManager<ApplicationUser> userManager)
        {
            this._userManager = userManager;
        }

        public async Task<string> CreateAsync(string firstName, string lastName, string placeOfResidence, string email, string phoneNumber)
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

        public void DeleteAsync(string id)
        {
            throw new System.NotImplementedException();
        }

        public Task<string> UpdateAsync(string id, string firstName, string lastName, string placeOfResidence, string email, string phoneNumber)
        {
            throw new System.NotImplementedException();
        }
    }
}
