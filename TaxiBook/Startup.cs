namespace TaxiBook
{
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
    using TaxiBook.Areas.Manager.Services;
    using TaxiBook.Areas.Manager.Services.Inerfaces;

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

            //services.AddIdentity<IdentityUser, IdentityRole>()
            //    .AddEntityFrameworkStores<DbContext>();

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

            //CreateRoles(serviceProvider).Wait();
        }

        //private async Task CreateRoles(IServiceProvider serviceProvider)
        //{
        //    //adding customs roles : Question 1
        //    var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        //    var UserManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
        //    string[] roleNames = new [] { "TaxiDriver", "Dispatcher", "Manager" };
        //    IdentityResult roleResult;
        //
        //    foreach (var roleName in roleNames)
        //    {
        //        var roleExist = await RoleManager.RoleExistsAsync(roleName);
        //        if (!roleExist)
        //        {
        //            //create the roles and seed them to the database: Question 2
        //            roleResult = await RoleManager.CreateAsync(new IdentityRole(roleName));
        //        }
        //    }
        //}
    }
}
