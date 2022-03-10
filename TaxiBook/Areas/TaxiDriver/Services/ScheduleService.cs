namespace TaxiBook.Areas.TaxiDriver.Services
{
    using System.Threading.Tasks;
    using Data;
    using Data.Models;
    using Services.Inerfaces;
    using ViewModels.Home;

    public class ScheduleService : IScheduleService
    {
        private readonly TaxiBookDbContext db;

        public ScheduleService(TaxiBookDbContext db) => this.db = db;

        public Task<WorkTimeDetailsViewModel> Details(string id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<string> ForthcomingАbsenceAsync(string from, string till)
        {
            var forthcomingАbsence = new Absence
            {
                From = from,
                Till = till,
            };

            await db.Absences.AddAsync(forthcomingАbsence);

            await db.SaveChangesAsync();

            return forthcomingАbsence.Id;
        }
    }
}
