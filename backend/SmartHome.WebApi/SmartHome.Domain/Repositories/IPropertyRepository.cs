using SmartHome.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Domain.Repositories
{
    public interface IPropertyRepository
    {
        Task Add(Property property);
        Task<PaginationReturnObject<Property>> GetPropertiesByUserId(Guid userId,Pagination pagination);
        Task<PaginationReturnObject<Property>> GetAllProperties(Pagination pagination);

        Task<PaginationReturnObject<Property>> GetPropertiesByStatus(PropertyStatus status, Pagination pagination);
        Task<Property> GetById(Guid id);
        Task Update(Property property);
        Task<CountriesAndCities> GetCountries();
        Task<List<Property>> GetPropertiesByCity(string city);
        Task<List<Property>> GetPropertiesByCountry(string country);
    }
}
