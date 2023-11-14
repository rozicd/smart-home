using Microsoft.EntityFrameworkCore;
using SmartHome.Data.Entities;
using SmartHome.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Data
{
    public class DatabaseContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<CountryEntity> Countries { get; set; }
        public DbSet<CityEntity> Cities { get; set; }
        public DbSet<PropertyEntity> Properties { get; set; }

        public DatabaseContext(DbContextOptions options) : base(options)
        {

        }

        public DatabaseContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CountryEntity>()
                .HasMany(c => c.Cities)
                .WithOne(city => city.Country)
                .HasForeignKey(city => city.CountryId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CityEntity>()
                .HasMany(city => city.Properties)
                .WithOne(property => property.City)
                .HasForeignKey(property => property.CityId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
