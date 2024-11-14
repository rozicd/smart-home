using SmartHome.Domain.Exceptions;
using SmartHome.Domain.Models;
using SmartHome.Domain.Repositories;
using SmartHome.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Application.Services
{
    public class CityService : ICityService
    {
        private readonly ICityRepository _cityRepository;
        private readonly ICountryRepository _countryRepository;

        public CityService(ICityRepository cityRepository, ICountryRepository countryRepository)
        {
            _cityRepository = cityRepository;
            _countryRepository = countryRepository;
        }

        public async Task AddCity(City city)
        {
            await _cityRepository.Add(city);
        }

        public async Task<IEnumerable<City>> GetAllCities()
        {
            return await _cityRepository.GetAllCities();
        }

        public async Task<City> GetCityByName(string name)
        {
            return await _cityRepository.GetByName(name);
        }

        public async Task<City> GetCityByNameAndCountry(string cityName, string countryName)
        {
            Country country = await _countryRepository.GetByName(countryName);
            City city = await _cityRepository.GetCityByNameAndCountry(cityName, country.Id);

            return city;
        }

        public async Task<City> GetCityById(Guid id)
        {
            return await _cityRepository.GetById(id);
        }
    }
}
