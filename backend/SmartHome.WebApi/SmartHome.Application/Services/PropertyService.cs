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
    public class PropertyService : IPropertyService
    {
        private readonly IPropertyRepository _propertyRepository;

        public PropertyService(IPropertyRepository propertyRepository)
        {
            _propertyRepository = propertyRepository;
        }

        public async Task AddProperty(Property property)
        {
            await _propertyRepository.Add(property);
        }

        public async Task<IEnumerable<Property>> GetPropertiesByUserId(Guid userId)
        {
            return await _propertyRepository.GetPropertiesByUserId(userId);
        }

        public async Task<IEnumerable<Property>> GetPropertiesByStatus(PropertyStatus status)
        {
            return await _propertyRepository.GetPropertiesByStatus(status);
        }

        public async Task<Property> GetPropertyById(Guid id)
        {
            return await _propertyRepository.GetById(id);
        }

        public async Task UpdateProperty(Property property)
        {
            await _propertyRepository.Update(property);
        }
    }
}
