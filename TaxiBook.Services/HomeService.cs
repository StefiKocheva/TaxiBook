namespace TaxiBook.Services
{
    using System;
    using System.Threading.Tasks;
    using Interfaces;

    public class HomeService : IHomeService
    {
        public async Task<string> GiveFeedbackAsync(string company, bool isLiked, string description)
        {
            throw new NotImplementedException();
        }
    }
}
