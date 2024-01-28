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
    public class PropertyRepository : IPropertyRepository
    {
        private readonly IMapper _mapper;
        private readonly DbSet<PropertyEntity> _properties;
        private readonly DatabaseContext _context;

        public PropertyRepository(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _properties = context.Set<PropertyEntity>();
            _mapper = mapper;
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
                .Where(p => p.UserId == userId);

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
    }
}
