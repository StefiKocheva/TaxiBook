﻿namespace TaxiBook.Data
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

        public DbSet<Booking> Bookings { get; set; }

        public DbSet<Company> Companies { get; set; }

        public DbSet<Feedback> Feedbacks { get; set; }

        public DbSet<Schedule> Schedules { get; set; }

        public DbSet<Taxi> Taxies { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var entityTypes = builder.Model.GetEntityTypes().ToList();

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

            builder.Entity<Booking>()
                .HasOne(b => b.CurrentLocation)
                .WithMany(cl => cl.CurrentLocations)
                .HasForeignKey(b => b.CurrentLocationId);

            builder.Entity<Booking>()
                .HasOne(b => b.EndLocation)
                .WithMany(el => el.EndLocations)
                .HasForeignKey(b => b.EndLocationId);

            builder.Entity<Booking>()
                .HasOne(b => b.User)
                .WithMany(u => u.Bookings)
                .HasForeignKey(b => b.UserId);

            builder.Entity<Booking>()
                .HasOne(b => b.Taxi)
                .WithMany(t => t.Bookings)
                .HasForeignKey(b => b.TaxiId);

            builder.Entity<Feedback>()
                .HasOne(f => f.Client)
                .WithMany(c => c.Feedbacks)
                .HasForeignKey(f => f.ClientId);

            builder.Entity<Absence>()
                .HasOne(a => a.Employee)
                .WithMany(e => e.Absences)
                .HasForeignKey(a => a.EmployeeId);

            builder.Entity<Company>()
                .HasOne(c => c.Address)
                .WithOne(a => a.Company)
                .HasForeignKey<Address>(c => c.CompanyId);
        }
    }
}
