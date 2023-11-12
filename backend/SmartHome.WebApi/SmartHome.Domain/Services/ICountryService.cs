using SmartHome.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Domain.Services
{
    public interface ICountryService
    {
        Task AddCountry(Country country);
        Task<IEnumerable<Country>> GetAllCountries();
        Task<Country> GetCountryByName(string name);

        Task<Country> GetCountryById(Guid id);
    }
}
