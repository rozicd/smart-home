using SmartHome.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Domain.Repositories
{
    public interface ICountryRepository
    {
        Task Add(Country country);
        Task<IEnumerable<Country>> GetAllCountries();
        Task<Country> GetById(Guid id);
        Task<Country> GetByName(string name); 

    }
}
