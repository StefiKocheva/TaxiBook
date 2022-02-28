namespace TaxiBook.Areas.TaxiDriver.Services.Inerfaces
{
    using System.Threading.Tasks;
    using ViewModels.Home;

    public interface IScheduleService
    {
        Task<string> ForthcomingАbsenceAsync(
            string from, 
            string till);

        Task<WorkTimeDetailsViewModel> Details(string id);
    }
}
