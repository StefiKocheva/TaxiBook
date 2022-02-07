namespace TaxiBook.Services.Interfaces
{
    using System.Threading.Tasks;

    public interface IHomeService
    {
        Task<string> GiveFeedbackAsync(string company, bool isLiked, string description);
    }
}
