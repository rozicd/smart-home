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
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository _countryRepository;

        public CountryService(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        public async Task AddCountry(Country country)
        {
            await _countryRepository.Add(country);
        }

        public async Task<IEnumerable<Country>> GetAllCountries()
        {
            return await _countryRepository.GetAllCountries();
        }
        public async Task<Country> GetCountryByName(string name)
        {
            return await _countryRepository.GetByName(name);
        }

        public async Task<Country> GetCountryById(Guid id)
        {
            return await _countryRepository.GetById(id);
        }
    }
}
