namespace TaxiBook.Areas.Dispatcher.Services
{
    using System.Threading.Tasks;
    using Data;
    using Data.Models;
    using Interfaces;
    using TaxiBook.Infrastructure.Services;
    using ViewModels.Home;

    public class ScheduleService : IScheduleService
    {
        private readonly TaxiBookDbContext db;
        private readonly ICurrentUserService currentUserService;

        public ScheduleService(
            TaxiBookDbContext db, 
            ICurrentUserService currentUserService)
        {
            this.db = db;
            this.currentUserService = currentUserService;
        }

        public async Task<string> CreateАbsenceAsync(
            string from, 
            string till)
        {
            var absence = new Absence
            {
                From = from,
                Till = till,
                EmployeeId = this.currentUserService.GetId(),
            };

            await this.db.Absences.AddAsync(absence);
            await this.db.SaveChangesAsync();

            return absence.Id;
        }

        public async Task<WorkTimeDetailsViewModel> Details(string id)
        {
            throw new System.NotImplementedException();
        }
    }
}
