using EF_Core_2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core_2.DatabaseContext
{
    internal class AirlineDbContext :DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=AirLineDB;Trusted_Connection=true;TrustServerCertificate=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Airline>()
                .HasMany(A=>A.Aircrafts)
                .WithOne(A => A.Airline)
                .HasForeignKey(A => A.AirlineId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Airline>()
                .HasMany(A => A.Employees)
                .WithOne(E => E.Airline)
                .HasForeignKey(E => E.AirlineId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Airline>()
                .HasMany(A=>A.Transactions)
                .WithOne(T=>T.Airline)
                .HasForeignKey(T=>T.AirlineId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<AircraftRoute>()
                .HasOne(R => R.Route)
                .WithMany(R => R.AircraftRoutes)
                .HasForeignKey(R => R.RouteId);

            modelBuilder.Entity<AircraftRoute>()
                .HasOne(R=>R.Aircraft)
                .WithMany(A=>A.AircraftRoutes)
                .HasForeignKey(R=>R.AircraftId);
                
        }

        public DbSet<Aircraft> Aircrafts { get; set; }
        public DbSet<Airline> Airlines { get; set; }
        public DbSet<AircraftRoute> AircraftRoutes { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

    }
}
