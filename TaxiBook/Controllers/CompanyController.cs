namespace TaxiBook.Controllers
{
    using CloudinaryDotNet;
    using CloudinaryDotNet.Actions;
    using Microsoft.AspNetCore.Mvc;
    using System.IO;
    using System.Threading.Tasks;
    using TaxiBook.Data;
    using TaxiBook.Data.Models;
    using TaxiBook.ViewModels.Companies;

    public class CompanyController : Controller
    {
        private readonly ApplicationDbContext db;

        public CompanyController(ApplicationDbContext db)
        {
            this.db = db;
        }

        public async Task<IActionResult> Create(CreateCompanyViewModel model)
        {
            var licenseUrl = string.Empty;

            if (this.ModelState.IsValid)
            {
                if (model.License != null && model.License.Length > 0)
                {
                    var fileName = Path.GetFileName(model.License.FileName);
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot", fileName);

                    using var fileStream = new FileStream(filePath, FileMode.Create);

                    await model.License.CopyToAsync(fileStream);

                    var account = new Account("taxibook", "413572826222444", "NHKg_TnitQUKUm_1XTGqTHd9zeg");

                    fileStream.Close();

                    var cloudinary = new Cloudinary(account);

                    var uploadParams = new ImageUploadParams()
                    {
                        File = new FileDescription(filePath),
                    };

                    var uploadResult = cloudinary.Upload(uploadParams);

                    System.IO.File.Delete(filePath);

                    licenseUrl = uploadResult.Url.ToString();
                }
            }

            var company = new Company()
            {
                Name = model.Name,
                Description = model.Description,
                PhoneNumber = model.PhoneNumber,
                Address = model.Address,
                LicenseUrl = licenseUrl,
            };

            await db.Companies.AddAsync(company);

            await db.SaveChangesAsync();

            return this.RedirectPermanent("/");
        }
    }
}
