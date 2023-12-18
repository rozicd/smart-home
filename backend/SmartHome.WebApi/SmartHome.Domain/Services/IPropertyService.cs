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
        Task<PaginationReturnObject<Property>> GetPropertiesByUserId(Guid userId,Pagination pagination);
        Task<PaginationReturnObject<Property>> GetPropertiesByStatus(PropertyStatus status, Pagination pagination);
        Task<Property> GetPropertyById(Guid id);
        Task UpdateProperty(Property property);
        Task ListenOnCharge(Property property);
    }
}
