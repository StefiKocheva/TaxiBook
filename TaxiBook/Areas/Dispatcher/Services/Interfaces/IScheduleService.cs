namespace TaxiBook.Areas.Dispatcher.Services.Interfaces
{
    using System.Threading.Tasks;
    using ViewModels.Home;

    public interface IScheduleService
    {
        Task<string> CreateАbsenceAsync(
            string from, 
            string till);

        Task<WorkTimeDetailsViewModel> Details(string id);
    }
}
