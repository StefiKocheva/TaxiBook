namespace TaxiBook.Infrastructure
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.DependencyInjection;

    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMvs(this IServiceCollection services)
        {
            services.AddControllersWithViews(options => options
                .Filters.Add(new AutoValidateAntiforgeryTokenAttribute()));

            services.AddRazorPages();
            
            return services;
        }
    }
}
