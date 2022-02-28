namespace TaxiBook.Services
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using CloudinaryDotNet;
    using CloudinaryDotNet.Actions;
    using Data;
    using Data.Models;
    using Interfaces;
    using Microsoft.AspNetCore.Http;
    using Microsoft.EntityFrameworkCore;
    using ViewModels.Companies;

    public class CompanyService : ICompanyService
    {
        private readonly TaxiBookDbContext db;

        public CompanyService(TaxiBookDbContext db) => this.db = db;

        public IEnumerable<CompanyDetailsViewModel> All() 
            => this.db
                .Companies
                .OrderBy(c => c.Name)
                .Select(c => new CompanyDetailsViewModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                    DailyTariff = c.DailyTariff,
                    NightTariff = c.NightTariff,
                    PhoneNumber = c.PhoneNumber,
                    // Address = c.Address - address of company
                    // Region = c.Region - area for orders
                })
                .ToHashSet();

        public async Task<string> CreateAsync(
            string name, 
            decimal dailyTariff, 
            decimal nightTariff, 
            string phoneNumber, 
            string description 
            /*IFormFile license*/)
        {
            //var licenseUrl = await this.UploadImageAsync(license);

            var company = new Company()
            {
                Name = name,
                DailyTariff = dailyTariff,
                NightTariff = nightTariff,
                PhoneNumber = phoneNumber,
                Description = description,
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
