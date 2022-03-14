namespace TaxiBook.Areas.Manager.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using Data;
    using Infrastructure.Services;
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

        public IEnumerable<CompanyDetailsViewModel> Overview()
            => this.db
            .Companies
            .Where(c => c.Employees.FirstOrDefault(e => e.Id == this.currentUserService.GetId()).CompanyId == c.Id)
            .Select(c => new CompanyDetailsViewModel()
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
            })
            .ToHashSet();

        public IEnumerable<EmpployeeDetailsViewModel> EmployeesInCompany()
            => this.db
            .Users
            .Where(u => u.EmployeeRole != Data.Models.Enums.EmployeeRole.None)
            .Select(u => new EmpployeeDetailsViewModel()
            {
                CompanyId = u.CompanyId,
                EmployeeRole = u.EmployeeRole,
            })
            .ToHashSet();
    }
}
