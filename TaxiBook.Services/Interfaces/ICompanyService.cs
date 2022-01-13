using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiBook.Services.Models.Companies;

namespace TaxiBook.Services.Interfaces
{
    public interface ICompanyService
    {
        public Task<string> CreateAsync(CreateCompanyViewModel model);
    }
}
