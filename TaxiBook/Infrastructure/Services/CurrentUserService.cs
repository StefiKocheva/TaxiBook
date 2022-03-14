namespace TaxiBook.Infrastructure.Services
{
    using System.Linq;
    using System.Security.Claims;
    using Data;
    using Data.Models;
    using Microsoft.AspNetCore.Http;

    public class CurrentUserService : ICurrentUserService
    {
        private readonly TaxiBookDbContext db;
        private ClaimsPrincipal user;

        public CurrentUserService(
            IHttpContextAccessor httpContextAccessor,
            TaxiBookDbContext db)
        {
            this.user = httpContextAccessor.HttpContext.User;
            this.db = db;
        }

        public string GetId()
            => this.GetUser().Id;

        public string GetUserName()
            => this.user.Identity.Name;

        public ApplicationUser GetUser()
            => this.db.Users
                .FirstOrDefault(u => u.UserName == this.GetUserName());
    }
}
