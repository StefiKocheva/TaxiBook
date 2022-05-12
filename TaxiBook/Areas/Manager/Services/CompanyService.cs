namespace TaxiBook.Areas.Manager.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Data;
    using Infrastructure.Services;
    using Microsoft.EntityFrameworkCore;
    using Services.Interfaces;
    using ViewModels.Companies;

    public class CompanyService : ICompanyService
    {
        private readonly ICurrentUserService currentUserService;
        private readonly TaxiBookDbContext db;

        public CompanyService(
            ICurrentUserService currentUserService, 
            TaxiBookDbContext db)
        {
            this.currentUserService = currentUserService;
            this.db = db;
        }

        public async Task<CompanyInformationViewModel> OverviewAsync()
            => await this.db
            .Companies
            .Where(c => c.Employees.FirstOrDefault(e => e.Id == this.currentUserService.GetId()).CompanyId == c.Id)
            .Select(c => new CompanyInformationViewModel()
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description,
                PhoneNumber = c.PhoneNumber,
                Province = c.Province,
                OneКilometerМileageDailyPrice = c.OneКilometerМileageDailyPrice,
                DailyPricePerCall = c.DailyPricePerCall,
                InitialDailyFee = c.InitialDailyFee,
                DailyPricePerMinuteStay = c.DailyPricePerMinuteStay,
                OneКilometerМileageNightPrice = c.OneКilometerМileageNightPrice,
                NightPricePerCall = c.NightPricePerCall,
                InitialNightFee = c.InitialNightFee,
                NightPricePerMinuteStay = c.NightPricePerMinuteStay,
                CountOfDispatchers = this.GetCountOfDispatchers(),
                CountOfTaxiDrivers = this.GetCountOfTaxiDrivers(),
            })
            .FirstOrDefaultAsync();

        private int GetCountOfDispatchers() 
            => this.db.Users
                .Where(u => u.CompanyId == this.currentUserService.GetUser().CompanyId)
                .Where(u => u.EmployeeRole == Data.Models.Enums.EmployeeRole.Dispatcher)
                .Count();

        private int GetCountOfTaxiDrivers()
            => this.db.Users
                .Where(u => u.CompanyId == this.currentUserService.GetUser().CompanyId)
                .Where(u => u.EmployeeRole == Data.Models.Enums.EmployeeRole.TaxiDriver)
                .Count();

        public async Task EditAsync(
            string id,
            string name, 
            string phoneNumber,
            string description,
            string province, 
            decimal? oneКilometerМileageDailyPrice,
            decimal? dailyPricePerCall, 
            decimal? initialDailyFee, 
            decimal? dailyPricePerMinuteStay, 
            decimal? oneКilometerМileageNightPrice, 
            decimal? nightPricePerCall, 
            decimal? initialNightFee,
            decimal? nightPricePerMinuteStay)
        {
            var company = this.db
                .Companies
                .Where(c => c.Id == id)
                .FirstOrDefault();

            if (company.Name != name && name != null)
            {
                company.Name = name;
            }

            if (company.PhoneNumber != phoneNumber && phoneNumber != null)
            {
                company.PhoneNumber = phoneNumber;
            }

            if (company.Description != description && description != null)
            {
                company.Description = description;
            }

            if (company.Province != province && province != null)
            {
                company.Province = province;
            }

            if (company.OneКilometerМileageDailyPrice != oneКilometerМileageDailyPrice && oneКilometerМileageDailyPrice != null)
            {
                company.OneКilometerМileageDailyPrice = oneКilometerМileageDailyPrice;
            }

            if (company.DailyPricePerCall != dailyPricePerCall && dailyPricePerCall != null)
            {
                company.DailyPricePerCall = dailyPricePerCall;
            }

            if (company.InitialDailyFee != initialDailyFee && initialDailyFee != null)
            {
                company.InitialDailyFee = initialDailyFee;
            }

            if (company.DailyPricePerMinuteStay != dailyPricePerMinuteStay && dailyPricePerMinuteStay != null)
            {
                company.DailyPricePerMinuteStay = dailyPricePerMinuteStay;
            }

            if (company.OneКilometerМileageNightPrice != oneКilometerМileageNightPrice && oneКilometerМileageNightPrice != null)
            {
                company.OneКilometerМileageNightPrice = oneКilometerМileageNightPrice;
            }

            if (company.NightPricePerCall != nightPricePerCall && nightPricePerCall != null)
            {
                company.NightPricePerCall = nightPricePerCall;
            }

            if (company.InitialNightFee != initialNightFee && initialNightFee != null)
            {
                company.InitialNightFee = initialNightFee;
            }

            if (company.DailyPricePerMinuteStay != dailyPricePerMinuteStay && dailyPricePerMinuteStay != null)
            {
                company.DailyPricePerMinuteStay = dailyPricePerMinuteStay;
            }

            await this.db.SaveChangesAsync();
        }
    }
}
