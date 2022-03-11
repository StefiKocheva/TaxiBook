namespace TaxiBook.Areas.Dispatcher.Services
{
    using System.Threading.Tasks;
    using Data;
    using Data.Models;
    using Interfaces;
    using ViewModels.Home;

    public class ScheduleService : IScheduleService
    {
        private readonly TaxiBookDbContext db;

        public ScheduleService(TaxiBookDbContext db) 
            => this.db = db;

        public async Task<string> CreateАbsenceAsync(
            string from, 
            string till)
        {
            var absence = new Absence
            {
               From = from,
               Till = till,
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
