namespace TaxiBook.Controllers
{
    using System.Threading.Tasks;
    using Services.Interfaces;
    using Services.ViewModels.Companies;
    using Microsoft.AspNetCore.Mvc;

    public class CompanyController : Controller
    {
        private readonly ICompanyService companyService;

        public CompanyController(ICompanyService companyService)
        {
            this.companyService = companyService;
        }

        [HttpGet]
        public IActionResult All()
        {
            return this.View();
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

            await this.companyService.CreateAsync(model);

            return this.RedirectPermanent("/");
        }
    }
}
