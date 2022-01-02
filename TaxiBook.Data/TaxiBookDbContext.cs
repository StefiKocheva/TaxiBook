using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Identity;
using TaxiBook.Data.Models;

namespace TaxiBook.Data
{
    public class TaxiBookDbContext : IdentityDbContext<ApplicationUser, IdentityRole, string>
    {
        public TaxiBookDbContext(DbContextOptions<TaxiBookDbContext> options)
            : base(options)
        {
        }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<Booking> Bookings { get; set; }

        public DbSet<Company> Companies { get; set; }

        public DbSet<Feedback> Feedbacks { get; set; }

        public DbSet<Taxi> Taxies { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var entityTypes = builder.Model.GetEntityTypes().ToList();


            builder.Entity<ApplicationUser>()
                .HasOne(u => u.Company)
                .WithMany(c => c.Employees)
                .HasForeignKey(u => u.CompanyId);

            builder.Entity<Taxi>()
                .HasOne(t => t.Driver)
                .WithMany(d => d.Taxies)
                .HasForeignKey(d => d.DriverId);

            builder.Entity<Booking>()
                .HasOne(b => b.CurrentLocation)
                .WithMany(cl => cl.CurrentLocations)
                .HasForeignKey(b => b.CurrentLocationId);

            builder.Entity<Booking>()
                .HasOne(b => b.EndLocation)
                .WithMany(el => el.EndLocations)
                .HasForeignKey(b => b.EndLocationId);

            builder.Entity<Booking>()
                .HasOne(b => b.Client)
                .WithMany(c => c.Bookings)
                .HasForeignKey(b => b.ClientId);

            builder.Entity<Booking>()
                .HasOne(b => b.Taxi)
                .WithMany(t => t.Bookings)
                .HasForeignKey(b => b.TaxiId);

            builder.Entity<Feedback>()
                .HasOne(f => f.User)
                .WithMany(u => u.Feedbacks)
                .HasForeignKey(f => f.UserId);

            builder.Entity<Taxi>()
                .HasOne(t => t.Company)
                .WithMany(c => c.Taxies)
                .HasForeignKey(t => t.CompanyId);

            builder.Entity<Taxi>()
                .HasOne(t => t.Driver)
                .WithMany(d => d.Taxies)
                .HasForeignKey(t => t.DriverId);

            builder.Entity<Taxi>()
                .HasOne(t => t.Location)
                .WithMany(l => l.Taxies)
                .HasForeignKey(t => t.LocationId);
        }
    }
}
