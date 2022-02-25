namespace TaxiBook
{
    using Areas.Dispatcher.Services;
    using Areas.Dispatcher.Services.Interfaces;
    using Areas.Manager.Services;
    using Areas.Manager.Services.Inerfaces;
    using Areas.Manager.Services.Interfaces;
    using Areas.TaxiDriver.Services;
    using Areas.TaxiDriver.Services.Inerfaces;
    using Data;
    using Data.Models;
    using Infrastructure;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Services;
    using Services.Interfaces;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<TaxiBookDbContext>(options =>
                options.UseSqlServer(this.Configuration.GetDefaultConnectionString(),
                x => x.MigrationsAssembly("TaxiBook.Data"))
                /*.UseLazyLoadingProxies()*/);
            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddDefaultIdentity<ApplicationUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<TaxiBookDbContext>();

            services
                .AddTransient<ICompanyService, CompanyService>()
                .AddTransient<Services.Interfaces.IOrderService, Services.OrderService>()
                .AddTransient<IFeedbackService, FeedbackService>()
                .AddTransient<IFavoriteService, FavoriteService>()
                .AddTransient<Areas.Dispatcher.Services.Interfaces.IScheduleService, Areas.Dispatcher.Services.ScheduleService>()
                .AddTransient<Areas.Dispatcher.Services.Interfaces.IOrderService, Areas.Dispatcher.Services.OrderService>()
                .AddTransient<Areas.TaxiDriver.Services.Inerfaces.IOrderService, Areas.TaxiDriver.Services.OrderService>()
                .AddTransient<Areas.TaxiDriver.Services.Inerfaces.IScheduleService, Areas.TaxiDriver.Services.ScheduleService>()
                .AddTransient<IEmployeeService, EmployeeService>()
                .AddTransient<Areas.Manager.Services.Interfaces.IScheduleService, Areas.Manager.Services.ScheduleService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseExceptionHandling(env);

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints();

            app.SeedData();
        }
    }
}
