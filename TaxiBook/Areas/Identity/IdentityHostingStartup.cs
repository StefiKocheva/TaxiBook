using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(TaxiBook.Areas.Identity.IdentityHostingStartup))]
namespace TaxiBook.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}