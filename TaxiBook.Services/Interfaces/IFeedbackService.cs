﻿namespace TaxiBook.Services.Interfaces
{
    using System.Threading.Tasks;

    public interface IFeedbackService
    {
        Task<string> CreateAsync(
            string company, 
            bool isLiked, 
            string description);
    }
}
