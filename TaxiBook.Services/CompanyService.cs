using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using TaxiBook.Data.Models;
using TaxiBook.Services.Interfaces;
using TaxiBook.Services.Models.Companies;

namespace TaxiBook.Services
{
    public class CompanyService : ICompanyService
    {
        public async Task<string> CreateAsync(CreateCompanyViewModel model)
        {
            var licenseUrl = string.Empty;

            
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
        }
    }
}
