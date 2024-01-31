using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SmartHome.Data.Entities;
using SmartHome.Data.Entities.SmartDevices;
using SmartHome.Domain.Exceptions;
using SmartHome.Domain.Models;
using SmartHome.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartHome.Data.Repositories
{
    public class PropertyRepository : IPropertyRepository
    {
        private readonly IMapper _mapper;
        private readonly DbSet<PropertyEntity> _properties;
        private readonly DbSet<UserEntity> _users;
        private readonly DbSet<SmartDeviceEntity> _smartDevices;
        private readonly DatabaseContext _context;

        public PropertyRepository(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _properties = context.Set<PropertyEntity>();
            _mapper = mapper;
            _users = context.Set<UserEntity>();
            _smartDevices = context.Set<SmartDeviceEntity>();
        }

        public async Task Add(Property property)
        {
            PropertyEntity propertyEntity = _mapper.Map<PropertyEntity>(property);
            propertyEntity.Status = PropertyStatus.Pending;
            await _properties.AddAsync(propertyEntity);
            await _context.SaveChangesAsync();
        }

        public async Task<PaginationReturnObject<Property>> GetPropertiesByUserId(Guid userId, Pagination pagination)
        {
            var query = _properties
                .Include(p => p.City)
                    .ThenInclude(c => c.Country)
                .Where(p => p.UserId == userId || p.SharedUsers.Any(u => u.Id == userId));

            var totalItems = await query.CountAsync();

            var properties = await query
                .Skip((pagination.PageNumber - 1) * pagination.PageSize)
                .Take(pagination.PageSize)
                .ToListAsync();

            return new PaginationReturnObject<Property>(_mapper.Map<IEnumerable<Property>>(properties), pagination.PageNumber, pagination.PageSize, totalItems);
        }

        public async Task<PaginationReturnObject<Property>> GetPropertiesByStatus(PropertyStatus status, Pagination pagination)
        {
            var query = _properties
                .Include(p => p.City)
                    .ThenInclude(c => c.Country)
                .Where(p => p.Status == status);

            var totalItems = await query.CountAsync();

            var properties = await query
                .Skip((pagination.PageNumber - 1) * pagination.PageSize)
                .Take(pagination.PageSize)
                .ToListAsync();

            return new PaginationReturnObject<Property>(_mapper.Map<IEnumerable<Property>>(properties), pagination.PageNumber, pagination.PageSize, totalItems);
        }
        public async Task<List<Property>> GetPropertiesByCountry(string country)
        {
            var query = _properties
                .Include(p => p.City)
                    .ThenInclude(c => c.Country)
                .Where(p => p.City.Country.Name == country);


            var properties = await query
                .ToListAsync();

            return (_mapper.Map<List<Property>>(properties));
        }
        public async Task<List<Property>> GetPropertiesByCity(string city)
        {
            var query = _properties
                .Include(p => p.City)
                    .ThenInclude(c => c.Country)
                .Where(p => p.City.Name == city);


            var properties = await query
                .ToListAsync();

            return (_mapper.Map<List<Property>>(properties));
        }

        public async Task<Property> GetById(Guid id)
        {
            var property = await _properties.FirstOrDefaultAsync(p => p.Id == id);
            if (property == null)
            {
                throw new ResourceNotFoundException($"Property with Id {id} not found.");
            }
            return _mapper.Map<Property>(property);
        }

        public async Task Update(Property property)
        {
            var propertyEntity = await _properties.FirstOrDefaultAsync(p => p.Id == property.Id);
            if (propertyEntity == null)
            {
                throw new ResourceNotFoundException($"Property with Id {property.Id} not found for update.");
            }

            propertyEntity.Status = property.Status;
            await _context.SaveChangesAsync();
        }

        public async Task<PaginationReturnObject<Property>> GetAllProperties(Pagination pagination)
        {
            var query = _properties
               .Include(p => p.City)
                   .ThenInclude(c => c.Country);

            var totalItems = await query.CountAsync();

            var properties = await query
                .Skip((pagination.PageNumber - 1) * pagination.PageSize)
                .Take(pagination.PageSize)
                .ToListAsync();

            return new PaginationReturnObject<Property>(_mapper.Map<IEnumerable<Property>>(properties), pagination.PageNumber, pagination.PageSize, totalItems);
        }

        public async Task<CountriesAndCities> GetCountries()
        {
            var query = _properties
               .Include(p => p.City)
                   .ThenInclude(c => c.Country);

            var properties = await query.ToListAsync();

            List<Country> countries = new List<Country>();
            List<City> cities = new List<City>();
            List<string> cityNames = new List<string>();
            List<string> countryNames = new List<string>();
            CountriesAndCities res = new CountriesAndCities();
            
            foreach (PropertyEntity p in properties)
            {
                City c = _mapper.Map<City>(p.City);
                Country co = _mapper.Map<Country>(p.City.Country);
                if (!cityNames.Contains(c.Name))
                { 
                    cities.Add(c);
                    cityNames.Add(c.Name);
                }
                if (!countryNames.Contains(co.Name))
                { 
                    countries.Add(co);
                    countryNames.Add(co.Name);
                }
            }
            res.Cities = cities;
            res.Countries = countries;
            return res;
        }

        public async Task AddUserPermision(Guid propertyId, User user)
        {
            var propertyEntity = await _properties.FirstOrDefaultAsync(p => p.Id == propertyId);
            if (propertyEntity == null)
            {
                throw new ResourceNotFoundException($"Proprerty with id {propertyId} was not found");
            }
            var userEntity = _users.FirstOrDefault(u => u.Email == user.Email);
            if (userEntity == null)
            {
                throw new ResourceNotFoundException($"Proprerty with id {propertyId} was not found");
            }
            if (!propertyEntity.SharedUsers.Contains(userEntity)) 
            {
                propertyEntity.SharedUsers.Add(userEntity);

                var devices = await _smartDevices.Where(d => d.PropertyId == propertyId).ToListAsync();

                foreach (var device in devices)
                {
                    if (!device.SharedUsers.Contains(userEntity))
                    {
                        device.SharedUsers.Add(userEntity);
                    }
                }


                await _context.SaveChangesAsync();
            }

        }

        public async Task RemoveUserPermision(Guid propertyId, User user)
        {
            var propertyEntity = await _properties.FirstOrDefaultAsync(p => p.Id == propertyId);
            if (propertyEntity == null)
            {
                throw new ResourceNotFoundException($"Property with id {propertyId} was not found");
            }

            var userEntity = propertyEntity.SharedUsers.FirstOrDefault(u => u.Id == user.Id);
            if (userEntity == null)
            {
                throw new ResourceNotFoundException($"User with Id {user.Id} was not found in property with id {propertyId}");
            }

            propertyEntity.SharedUsers.Remove(userEntity);
            var devices = await _smartDevices.Where(d => d.PropertyId == propertyId).ToListAsync();

            foreach (var device in devices)
            {
                
                 device.SharedUsers.Remove(userEntity);
                
            }

            await _context.SaveChangesAsync();
        }
    }
}
