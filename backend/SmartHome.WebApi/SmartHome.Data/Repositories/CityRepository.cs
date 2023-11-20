using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SmartHome.Data.Entities;
using SmartHome.Domain.Exceptions;
using SmartHome.Domain.Models;
using SmartHome.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHome.Data.Repositories
{
    public class CityRepository : ICityRepository
    {
        private readonly IMapper _mapper;
        private readonly DbSet<CityEntity> _cities;
        private readonly DatabaseContext _context;

        public CityRepository(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _cities = context.Set<CityEntity>();
            _mapper = mapper;
        }

        public async Task Add(City city)
        {
            CityEntity cityEntity = _mapper.Map<CityEntity>(city);
            await _cities.AddAsync(cityEntity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<City>> GetAllCities()
        {
            var cities = await _cities.Include(c => c.Country).ToListAsync();
            return _mapper.Map<IEnumerable<City>>(cities);
        }
        public async Task<City> GetByName(string name)
        {
            var city = await _cities.FirstOrDefaultAsync(c => c.Name == name);
            if (city == null)
            {
                throw new ResourceNotFoundException($"City with name '{name}' not found.");
            }
            return _mapper.Map<City>(city);
        }
        public async Task<City> GetById(Guid id)
        {
            var city = await _cities.FirstOrDefaultAsync(c => c.Id == id);
            if (city == null)
            {
                throw new ResourceNotFoundException($"City with Id {id} not found.");
            }
            return _mapper.Map<City>(city);
        }

        public async Task<City> GetCityByNameAndCountry(string cityName, Guid countryId)
        {
            var city = await _cities
                .Include(c => c.Country)
                .FirstOrDefaultAsync(c => c.Name == cityName && c.CountryId == countryId);

            if (city == null)
            {
                throw new ResourceNotFoundException($"City with name '{cityName}' in country with Id '{countryId}' not found.");
            }

            return _mapper.Map<City>(city);
        }
    }
}
