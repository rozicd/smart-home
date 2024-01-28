using CsvHelper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SmartHome.Data.Entities;
using SmartHome.Data.Entities.SmartDevices;
using SmartHome.Domain.Models;
using SmartHome.Domain.Models.SmartDevices;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Globalization;
using System.Linq;
using System.Numerics;
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
        public DbSet<LampEntity> Lamps { get; set; }
        public DbSet<EnvironmentalConditionsSensorEntity> environmentalConditionsSensors { get; set; }
        public DbSet<AirConditionerEntity> airConditioners { get; set; }
        public DbSet<ActivationTokenEntity> ActivationTokens { get; set; }
        public DbSet<SmartDeviceEntity> SmartDevices { get; set; }
        public DbSet<SprinkleModeEntity> SprinkleModes { get; set; }

        public DbSet<WashingMachineModeEntity> WashingMachineModes { get; set; }





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

            SeedCountriesAndCities(modelBuilder);

            modelBuilder.Entity<EnvironmentalConditionsSensorEntity>()
                .ToTable("EnvironmentalConditionsSensors")
                .HasBaseType<SmartDeviceEntity>();
            modelBuilder.Entity<AirConditionerEntity>()
                .ToTable("AirConditioners")
                .HasBaseType<SmartDeviceEntity>();
            modelBuilder.Entity<WashingMachineEntity>()
                .ToTable("WashingMachines")
                .HasBaseType<SmartDeviceEntity>();
            modelBuilder.Entity<LampEntity>()
                .ToTable("Lamps")
                .HasBaseType<SmartDeviceEntity>();
            modelBuilder.Entity<CarGateEntity>()
                .ToTable("CarGates")
                .HasBaseType<SmartDeviceEntity>();
            modelBuilder.Entity<SprinklerEntity>()
                .ToTable("Sprinklers")
                .HasBaseType<SmartDeviceEntity>();
            modelBuilder.Entity<SolarPanelSystemEntity>()
                .ToTable("SolarPanelSystems")
                .HasBaseType<SmartDeviceEntity>();
            modelBuilder.Entity<HomeBatteryEntity>()
                .ToTable("HomeBatteries")
                .HasBaseType<SmartDeviceEntity>();
            modelBuilder.Entity<CarChargerEntity>()
                .ToTable("CarChargers")
                .HasBaseType<SmartDeviceEntity>();


        }


        private void SeedCountriesAndCities(ModelBuilder modelBuilder)
        {
            var countries = ReadCountriesFromCsv();
            var cities = ReadCitiesFromCsv(countries);

            modelBuilder.Entity<CountryEntity>().HasData(countries);
            modelBuilder.Entity<CityEntity>().HasData(cities);
        }

        private List<CountryEntity> ReadCountriesFromCsv()
        {
            var countries = new List<CountryEntity>();

            using (var reader = new StreamReader("Countries.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Read();
                csv.ReadHeader();

                var uniqueCountries = new HashSet<string>();

                while (csv.Read())
                {
                    var countryName = csv.GetField<string>(" Country").Trim();

                    if (uniqueCountries.Add(countryName))
                    {
                        var country = new CountryEntity
                        {
                            Id = Guid.NewGuid(),
                            Name = countryName
                        };

                        countries.Add(country);
                    }
                }
            }

            return countries;
        }

        private List<CityEntity> ReadCitiesFromCsv(List<CountryEntity> countries)
        {
            var cities = new List<CityEntity>();

            using (var reader = new StreamReader("Countries.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Read();
                csv.ReadHeader();

                var uniqueCities = new HashSet<string>();

                while (csv.Read())
                {
                    var cityName = csv.GetField<string>("City").Trim();
                    var countryName = csv.GetField<string>(" Country").Trim();

                    if (uniqueCities.Add(cityName))
                    {
                        var country = countries.FirstOrDefault(c => c.Name == countryName);

                        if (country != null)
                        {
                            var city = new CityEntity
                            {
                                Id = Guid.NewGuid(),
                                Name = cityName,
                                CountryId = country.Id
                            };

                            cities.Add(city);
                        }
                    }
                }
            }

            return cities;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.EnableSensitiveDataLogging(false);
            optionsBuilder.UseLoggerFactory(null);


            optionsBuilder.LogTo(_ => { }, LogLevel.None);  

        }
    }


}
