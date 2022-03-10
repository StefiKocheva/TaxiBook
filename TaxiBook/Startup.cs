namespace TaxiBook
{
    using Areas.Manager.Services;
    using Areas.Manager.Services.Inerfaces;
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
                options.UseSqlServer(this.Configuration.GetDefaultConnectionString()));
            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddDefaultIdentity<ApplicationUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<TaxiBookDbContext>();

            services
                .AddTransient<ICompanyService, CompanyService>()
                .AddTransient<IOrderService, OrderService>()
                .AddTransient<IFeedbackService, FeedbackService>()
                .AddTransient<IFavoriteService, FavoriteService>()
                .AddTransient<Areas.Dispatcher.Services.Interfaces.IScheduleService, Areas.Dispatcher.Services.ScheduleService>()
                .AddTransient<Areas.Dispatcher.Services.Interfaces.IOrderService, Areas.Dispatcher.Services.OrderService>()
                .AddTransient<Areas.TaxiDriver.Services.Inerfaces.IOrderService, Areas.TaxiDriver.Services.OrderService>()
                .AddTransient<Areas.TaxiDriver.Services.Inerfaces.IScheduleService, Areas.TaxiDriver.Services.ScheduleService>()
                .AddTransient<IEmployeeService, EmployeeService>()
                .AddTransient<Areas.Manager.Services.Interfaces.IScheduleService, ScheduleService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env /*IServiceProvider serviceProvider*/)
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
