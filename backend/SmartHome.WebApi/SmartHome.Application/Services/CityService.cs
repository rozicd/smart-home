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

        public CityService(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
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

        public async Task<City> GetCityById(Guid id)
        {
            return await _cityRepository.GetById(id);
        }
    }
}
