namespace TaxiBook.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using TaxiBook.Data;
    using TaxiBook.Data.Models;

    public class CreateController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly TaxiBookDbContext db;
        private readonly UserManager<ApplicationUser> userManager;

        public CreateController(
            RoleManager<IdentityRole> roleManager, 
            IHttpContextAccessor httpContextAccessor, 
            TaxiBookDbContext db, 
            UserManager<ApplicationUser> userManager)
        {
            _roleManager = roleManager;
            this.httpContextAccessor = httpContextAccessor;
            this.db = db;
            this.userManager = userManager;
        }

        public async Task<IActionResult> Roles()
        {
            var roles = new [] { "TaxiDriver", "Dispatcher", "Manager" };
        
            foreach (var role in roles)
            {
                await this._roleManager
                    .CreateAsync(new IdentityRole(role));
            }
        
            return this.RedirectPermanent("/");
        }

        public async Task User()
        {
            var userName = this.httpContextAccessor.HttpContext.User.Identity.Name;

            var user = this.db.Users.FirstOrDefault(x => x.UserName == userName);

            await this.userManager.AddToRoleAsync(user, "Manager");
        }
    }
}
