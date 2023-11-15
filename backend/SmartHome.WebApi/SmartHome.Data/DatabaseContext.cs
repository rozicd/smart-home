using CsvHelper;
using Microsoft.EntityFrameworkCore;
using SmartHome.Data.Entities;
using SmartHome.Domain.Models;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Globalization;
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

            SeedCountriesAndCities(modelBuilder);
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

            using (var reader = new StreamReader("../Smarthome.Data/countries.csv"))
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

            using (var reader = new StreamReader("../Smarthome.Data/countries.csv"))
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
    }


}
