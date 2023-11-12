using SmartHome.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Domain.Services
{
    public interface IPropertyService
    {
        Task AddProperty(Property property);
        Task<IEnumerable<Property>> GetPropertiesByUserId(Guid userId);
        Task<IEnumerable<Property>> GetPropertiesByStatus(PropertyStatus status);
        Task<Property> GetPropertyById(Guid id);
        Task UpdateProperty(Property property);
    }
}
