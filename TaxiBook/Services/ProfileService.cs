namespace TaxiBook.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Data;
    using Infrastructure.Services;
    using Interfaces;
    using ViewModels.Profiles;

    public class ProfileService : IProfileService
    {
        private readonly TaxiBookDbContext db;
        private readonly ICurrentUserService currentUserService;

        public ProfileService(
            TaxiBookDbContext db, 
            ICurrentUserService currentUserService)
        {
            this.db = db;
            this.currentUserService = currentUserService;
        }

        public IEnumerable<ProfileDetailsViewModel> Overview()
            => this.db
            .Users
            .Where(u => u.Id == this.currentUserService.GetId())
            .Select(u => new ProfileDetailsViewModel()
            {
                FirstName = u.FirstName,
                LastName = u.LastName,
                PhoneNumber = u.PhoneNumber,
                Email = u.Email,
                ImageUrl = u.ImageUrl,
            })
            .ToHashSet();

        public async Task UpdateAsync(
            string firstName, 
            string lastName, 
            string email, 
            string phoneNumber)
        {
            var user = this.currentUserService.GetUser();

            user.FirstName = firstName;
            user.LastName = lastName;
            user.Email = email;
            user.PhoneNumber = phoneNumber;

            await this.db.SaveChangesAsync();
        }
    }
}
