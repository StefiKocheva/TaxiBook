using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace TaxiBook.Controllers
{
    public class CreateController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public CreateController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<IActionResult> Roles()
        {
            var roles = new [] {"TaxiDriver", "Dispatcher", "Manager"};

            foreach (var role in roles)
            {
                await this._roleManager.CreateAsync(new IdentityRole(role));
            }

            return this.RedirectPermanent("/");
        }
    }
}
