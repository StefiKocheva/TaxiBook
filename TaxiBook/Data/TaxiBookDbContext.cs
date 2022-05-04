namespace TaxiBook.Data
{
    using System.Linq;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.AspNetCore.Identity;
    using Models;

    public class TaxiBookDbContext : IdentityDbContext<ApplicationUser, IdentityRole, string>
    {
        public TaxiBookDbContext(DbContextOptions<TaxiBookDbContext> options)
            : base(options) 
        {
        }

        public DbSet<Absence> Absences { get; set; }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Company> Companies { get; set; }

        public DbSet<Favorite> Favorites { get; set; }

        public DbSet<Feedback> Feedbacks { get; set; }

        public DbSet<Schedule> Schedules { get; set; }

        public DbSet<Taxi> Taxies { get; set; }

        public DbSet<WorkTime> WorkTimes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var entityTypes = builder.Model
                .GetEntityTypes()
                .ToList();

            builder.Entity<ApplicationUser>()
                .HasOne(u => u.Company)
                .WithMany(c => c.Employees)
                .HasForeignKey(u => u.CompanyId);

            builder.Entity<ApplicationUser>()
                .HasOne(u => u.Schedule)
                .WithOne(s => s.Employee)
                .HasForeignKey<Schedule>(u => u.EmployeeId);

            builder.Entity<ApplicationUser>()
                .HasOne(u => u.Address)
                .WithOne(a => a.User)
                .HasForeignKey<Address>(u => u.UserId);

            builder.Entity<Taxi>()
                .HasOne(t => t.Driver)
                .WithMany(d => d.Taxies)
                .HasForeignKey(d => d.DriverId);

            builder.Entity<Taxi>()
                .HasOne(t => t.Location)
                .WithMany(l => l.Taxies)
                .HasForeignKey(t => t.LocationId);

            builder.Entity<Taxi>()
                .HasOne(t => t.Company)
                .WithMany(c => c.Taxies)
                .HasForeignKey(t => t.CompanyId);

            builder.Entity<Order>()
                .HasOne(o => o.CurrentLocation)
                .WithMany(cl => cl.CurrentLocations)
                .HasForeignKey(o => o.CurrentLocationId);

            builder.Entity<Order>()
                .HasOne(o => o.EndLocation)
                .WithMany(el => el.EndLocations)
                .HasForeignKey(o => o.EndLocationId);

            builder.Entity<Order>()
                .HasOne(o => o.User)
                .WithMany(u => u.Orders)
                .HasForeignKey(o => o.UserId);

            builder.Entity<Order>()
                .HasOne(o => o.Taxi)
                .WithMany(t => t.Orders)
                .HasForeignKey(o => o.TaxiId);

            builder.Entity<Order>()
                .HasOne(o => o.Company)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.CompanyId);

            builder.Entity<Feedback>()
                .HasOne(f => f.Client)
                .WithMany(c => c.Feedbacks)
                .HasForeignKey(f => f.ClientId);

            builder.Entity<Feedback>()
                .HasOne(f => f.Company)
                .WithMany(c => c.Feedbacks)
                .HasForeignKey(f => f.CompanyId);

            builder.Entity<Absence>()
                .HasOne(a => a.Employee)
                .WithMany(e => e.Absences)
                .HasForeignKey(a => a.EmployeeId);

            builder.Entity<Absence>()
                .HasOne(a => a.Company)
                .WithMany(c => c.Absences)
                .HasForeignKey(a => a.CompanyId);

            builder.Entity<WorkTime>()
                .HasOne(wt => wt.Employee)
                .WithMany(e => e.WorkTimes)
                .HasForeignKey(wt => wt.EmployeeId);

            builder.Entity<Company>()
                .HasOne(c => c.Location)
                .WithOne(a => a.Company)
                .HasForeignKey<Address>(c => c.CompanyId);

            //builder.Entity<Company>()
            //    .HasOne(o => o.Province)
            //    .WithMany(p => p.Provinces)
            //    .HasForeignKey(o => o.ProvinceId);

            builder.Entity<Favorite>()
                .HasOne(f => f.Client)
                .WithMany(c => c.Favorites)
                .HasForeignKey(f => f.ClientId);
        }
    }
}
