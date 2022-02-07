namespace TaxiBook.Areas.Dispatcher.Services
{
    using System;
    using System.Threading.Tasks;

    public interface IHomeService
    {
        Task<string> ForthcomingАbsenceAsync(DateTime from, DateTime till);
    }
}
