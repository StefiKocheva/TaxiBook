namespace TaxiBook.Services
{
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using CloudinaryDotNet;
    using CloudinaryDotNet.Actions;
    using Data;
    using Infrastructure.Services;
    using Interfaces;
    using Microsoft.AspNetCore.Http;
    using Microsoft.EntityFrameworkCore;
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

        public async Task<ProfileInformationViewModel> OverviewAsync()
            => await this.db
            .Users
            .Where(u => u.Id == this.currentUserService.GetId())
            .Select(u => new ProfileInformationViewModel()
            {
                Id = u.Id,
                FirstName = u.FirstName,
                LastName = u.LastName,
                PhoneNumber = u.PhoneNumber,
                Email = u.Email,
                ImageUrl = u.ImageUrl,
            })
            .FirstOrDefaultAsync();

        public async Task EditAsync(
            string firstName, 
            string lastName, 
            string email, 
            string phoneNumber)
        {
            var user = this.currentUserService.GetUser();

            if (user.FirstName != firstName && firstName != null)
            {
                user.FirstName = firstName;
            }

            if (user.LastName != lastName && lastName != null)
            {
                user.LastName = lastName;
            }

            if (user.Email != email && email != null)
            {
                user.Email = email;
            }

            if (user.PhoneNumber != phoneNumber && phoneNumber != null)
            {
                user.PhoneNumber = phoneNumber;
            }

            await this.db.SaveChangesAsync();
        }

        public async Task ChangeProfilePictureAsync(IFormFile profilePicture)
        {
            var user = this.currentUserService.GetUser();

            if (profilePicture != null)
            {
                string imageUrl = await this.UploadImageAsync(profilePicture);

                user.ImageUrl = imageUrl;
            }

            await this.db.SaveChangesAsync();
        }

        private async Task<string> UploadImageAsync(IFormFile profilePicture)
        {
            var imageUrl = string.Empty;

            if (profilePicture is { Length: > 0 })
            {
                var fileName = Path.GetFileName(profilePicture.FileName);
                var filePath = Path.Combine(
                    Directory.GetCurrentDirectory(),
                    @"wwwroot",
                    fileName ?? string.Empty);

                await using var fileStream = new FileStream(filePath, FileMode.Create);

                await profilePicture.CopyToAsync(fileStream);

                var account = new Account("taxibook", "413572826222444", "NHKg_TnitQUKUm_1XTGqTHd9zeg");

                fileStream.Close();

                var cloudinary = new Cloudinary(account);

                var uploadParams = new ImageUploadParams()
                {
                    File = new FileDescription(filePath),
                };

                var uploadResult = cloudinary.Upload(uploadParams);

                File.Delete(filePath);

                imageUrl = uploadResult.Url.ToString();
            }

            return imageUrl;
        }
    }
}
