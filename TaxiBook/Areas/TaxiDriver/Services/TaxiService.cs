namespace TaxiBook.Areas.TaxiDriver.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Data;
    using Infrastructure.Services;
    using Interfaces;
    using Microsoft.EntityFrameworkCore;
    using ViewModels.Taxies;

    public class TaxiService : ITaxiService
    {
        private readonly TaxiBookDbContext db;
        private readonly ICurrentUserService currentUserService;

        public TaxiService(
            TaxiBookDbContext db, 
            ICurrentUserService currentUserService)
        {
            this.db = db;
            this.currentUserService = currentUserService;
        }

        public async Task EditAsync(
            string brand, 
            string model, 
            string numberPlate)
        {
            var taxiDriver = this.currentUserService.GetUser();
            var taxi = this.db
                .Taxies
                .Where(t => t.Driver == taxiDriver)
                .FirstOrDefault();

            if (taxi.Brand != brand && brand != null)
            {
                taxi.Brand = brand;
            }

            if (taxi.Model != model && model != null)
            {
                taxi.Model = model;
            }

            if (taxi.NumberPlate != numberPlate && numberPlate != null)
            {
                taxi.NumberPlate = numberPlate;
            }

            await this.db.SaveChangesAsync();
        }

        public async Task<TaxiInformationViewModel> OverviewAsync()
            => await this.db
            .Taxies
            .Where(t => t.Driver == this.currentUserService.GetUser())
            .Select(t => new TaxiInformationViewModel()
            {
                Id = t.Id,
                Brand = t.Brand,
                Model = t.Model,
                NumberPlate = t.NumberPlate,
            })
            .FirstOrDefaultAsync();
    }
}
