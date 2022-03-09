namespace TaxiBook.Controllers
{
    using System.Threading.Tasks;
    using Services.Interfaces;
    using Services.ViewModels.Companies;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using TaxiBook.Data.Models;
    using TaxiBook.Data;
    using System.Linq;

    public class CompaniesController : Controller
    {
        private readonly ICompanyService companyService;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly TaxiBookDbContext db;

        public CompaniesController(ICompanyService companyService, IHttpContextAccessor httpContextAccessor, UserManager<ApplicationUser> userManager, TaxiBookDbContext db)
        {
            this.companyService = companyService;
            this.httpContextAccessor = httpContextAccessor;
            this.userManager = userManager;
            this.db = db;
        }

        [HttpGet]
        public IActionResult All()
        {
            var model = new CompanyListingViewModel();

            model.Companies = this.companyService.All();

            return this.View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCompanyViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest();
            }

            await this.companyService.CreateAsync(
                model.Name,
                model.PhoneNumber,
                model.Description,
                //model.License,
                model.Province,
                model.OneКilometerМileageDailyPrice,
                model.OneКilometerМileageNightPrice,
                model.DailyPricePerCall,
                model.NightPricePerCall,
                model.InitialDailyFee,
                model.InitialNightFee,
                model.DailyPricePerMinuteStay,
                model.NightPricePerMinuteStay);

            return this.RedirectToAction("All");
        }
    }
}
