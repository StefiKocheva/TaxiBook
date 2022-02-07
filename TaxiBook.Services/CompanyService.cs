namespace TaxiBook.Services
{
    using System.IO;
    using System.Threading.Tasks;
    using CloudinaryDotNet;
    using CloudinaryDotNet.Actions;
    using Data;
    using Interfaces;
    using Microsoft.AspNetCore.Http;
    using Models.Companies;
    using TaxiBook.Data.Models;

    public class CompanyService : ICompanyService
    {
        private readonly TaxiBookDbContext db;

        public CompanyService(TaxiBookDbContext db)
        {
            this.db = db;
        }

        public async Task<string> CreateAsync(CreateCompanyViewModel model)
        {
            var licenseUrl = await this.UploadImageAsync(model.License);

            var company = new Company()
            {
                Name = model.Name,
                PhoneNumber = model.PhoneNumber,
                Address = model.Address,
                LicenseUrl = licenseUrl,
            };

            await db.Companies.AddAsync(company);

            await db.SaveChangesAsync();

            return company.Id;
        }

        private async Task<string> UploadImageAsync(IFormFile license)
        {
            var licenseUrl = string.Empty;

            if (license is { Length: > 0 })
            {
                var fileName = Path.GetFileName(license.FileName);
                var filePath = Path.Combine(
                    Directory.GetCurrentDirectory(),
                    @"wwwroot",
                    fileName ?? string.Empty);

                await using var fileStream = new FileStream(filePath, FileMode.Create);

                await license.CopyToAsync(fileStream);

                var account = new Account("taxibook", "413572826222444", "NHKg_TnitQUKUm_1XTGqTHd9zeg");

                fileStream.Close();

                var cloudinary = new Cloudinary(account);

                var uploadParams = new ImageUploadParams()
                {
                    File = new FileDescription(filePath),
                };

                var uploadResult = cloudinary.Upload(uploadParams);

                File.Delete(filePath);

                licenseUrl = uploadResult.Url.ToString();
            }

            return licenseUrl;
        }
    }
}
