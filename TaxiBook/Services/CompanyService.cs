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
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Infrastructure.Services;
    using ViewModels.Companies;

    public class CompanyService : ICompanyService
    {
        private readonly TaxiBookDbContext db;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ICurrentUserService currentUserService;

        public CompanyService(
            TaxiBookDbContext db, 
            UserManager<ApplicationUser> userManager,
            ICurrentUserService currentUserService) 
        {
            this.db = db;
            this.userManager = userManager;
            this.currentUserService = currentUserService;
        }

        public IEnumerable<CompanyDetailsViewModel> All() 
            => this.db
                .Companies
                .OrderByDescending(c => c.CreatedOn)
                .Select(c => new CompanyDetailsViewModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                    PhoneNumber = c.PhoneNumber,
                    Description = c.Description,
                    //License = c.License,
                    Province = c.Province, 
                    OneКilometerМileageDailyPrice = c.OneКilometerМileageDailyPrice,
                    OneКilometerМileageNightPrice = c.OneКilometerМileageNightPrice,
                    DailyPricePerCall = c.DailyPricePerCall,
                    NightPricePerCall = c.NightPricePerCall,
                    InitialDailyFee = c.InitialDailyFee,
                    InitialNightFee = c.InitialNightFee,
                    DailyPricePerMinuteStay = c.DailyPricePerMinuteStay,
                    NightPricePerMinuteStay = c.NightPricePerMinuteStay,
                })
                .ToHashSet();

        public async Task<string> CreateAsync(
            string name, 
            string phoneNumber,
            string description,
            /*IFormFile license,*/
            string province,
            decimal? oneКilometerМileageDailyPrice,
            decimal? oneКilometerМileageNightPrice,
            decimal? dailyPricePerCall,
            decimal? nightPricePerCall,
            decimal? initialDailyFee,
            decimal? initialNightFee,
            decimal? dailyPricePerMinuteStay,
            decimal? nightPricePerMinuteStay)
        {
            //var licenseUrl = await this.UploadImageAsync(license);

            var company = new Company()
            {
                Name = name,
                PhoneNumber = phoneNumber,
                Description = description,
                //LicenseUrl = licenseUrl,
                Province = province,
                OneКilometerМileageDailyPrice = oneКilometerМileageDailyPrice,
                OneКilometerМileageNightPrice = oneКilometerМileageNightPrice,
                DailyPricePerCall = dailyPricePerCall,
                NightPricePerCall = nightPricePerCall,
                InitialDailyFee = initialDailyFee,
                InitialNightFee = initialNightFee,
                DailyPricePerMinuteStay = dailyPricePerMinuteStay,
                NightPricePerMinuteStay = nightPricePerMinuteStay,
            };

            await this.db.Companies.AddAsync(company);
            await this.db.SaveChangesAsync();

            var currentUser = this.currentUserService.GetUser();

            await this.userManager.AddToRoleAsync(currentUser, "Manager");

            currentUser.CompanyId = company.Id;

            await this.db.SaveChangesAsync();

            return company.Id;
        }

        public async Task<CompanyDetailsViewModel> DetailsAsync(string id)
            => await this.db
                .Companies
                .Where(c => c.Id == id)
                .Select(c => new CompanyDetailsViewModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                    Description = c.Description,
                    OneКilometerМileageDailyPrice = c.OneКilometerМileageDailyPrice,
                    DailyPricePerCall = c.DailyPricePerCall,
                    InitialDailyFee = c.InitialDailyFee,
                    DailyPricePerMinuteStay= c.DailyPricePerMinuteStay,
                    OneКilometerМileageNightPrice = c.OneКilometerМileageNightPrice,
                    NightPricePerCall = c.NightPricePerCall,
                    InitialNightFee = c.InitialNightFee,
                    NightPricePerMinuteStay = c.NightPricePerMinuteStay,
                })
                .FirstOrDefaultAsync();

        public IEnumerable<CompanyDetailsViewModel> TopFive()
            => this.db
                .Companies
                .Select(c => new CompanyDetailsViewModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                    PhoneNumber = c.PhoneNumber,
                    Province = c.Province,
                    OneКilometerМileageDailyPrice = c.OneКilometerМileageDailyPrice,
                    OneКilometerМileageNightPrice = c.OneКilometerМileageNightPrice,
                })
                .Take(5)?
                .ToHashSet();

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
