namespace TaxiBook.Areas.TaxiDriver.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using Data;
    using Infrastructure.Services;
    using Interfaces;
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

        public IEnumerable<TaxiDetailsViewModel> Overview()
            => this.db
            .Taxies
            .Where(t => t.DriverId == this.currentUserService.GetId())
            .Select(t => new TaxiDetailsViewModel()
            {
                Brand = t.Brand,
                Model = t.Model,
                NumberPlate = t.NumberPlate,
            })
            .ToHashSet();
    }
}
