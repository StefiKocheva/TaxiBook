using TaxiBook.Services.Interfaces;

namespace TaxiBook.Controllers
{
    using CloudinaryDotNet;
    using CloudinaryDotNet.Actions;
    using Microsoft.AspNetCore.Mvc;
    using System.IO;
    using System.Threading.Tasks;
    using TaxiBook.Data;
    using TaxiBook.Data.Models;
    using TaxiBook.Services.Models.Companies;

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
        public IActionResult Add()
        {
            return this.View();
        }

        public async Task<IActionResult> Create(CreateCompanyViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest();
            }

            await this.companyService.CreateAsync(model);

            return this.RedirectPermanent("/");
        }
    }
}
