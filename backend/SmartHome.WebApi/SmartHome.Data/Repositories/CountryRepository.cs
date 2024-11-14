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
    public class CountryRepository : ICountryRepository
    {
        private readonly IMapper _mapper;
        private readonly DbSet<CountryEntity> _countries;
        private readonly DatabaseContext _context;

        public CountryRepository(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _countries = context.Set<CountryEntity>();
            _mapper = mapper;
        }

        public async Task Add(Country country)
        {
            CountryEntity countryEntity = _mapper.Map<CountryEntity>(country);
            await _countries.AddAsync(countryEntity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Country>> GetAllCountries()
        {
            var countries = await _countries.ToListAsync();
            return _mapper.Map<IEnumerable<Country>>(countries);
        }

        public async Task<Country> GetByName(string name)
        {
            var country = await _countries.FirstOrDefaultAsync(c => c.Name == name);
            if (country == null)
            {
                throw new ResourceNotFoundException($"Country with name '{name}' not found.");
            }
            return _mapper.Map<Country>(country);
        }

        public async Task<Country> GetById(Guid id)
        {
            var country = await _countries.FirstOrDefaultAsync(c => c.Id == id);
            if (country == null)
            {
                throw new ResourceNotFoundException($"Country with Id {id} not found.");
            }
            return _mapper.Map<Country>(country);
        }
    }
}
