using SmartHome.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Domain.Repositories
{
    public interface ICityRepository
    {
        Task Add(City city);
        Task<IEnumerable<City>> GetAllCities();
        Task<City> GetById(Guid id);
        Task<City> GetByName(string name);
        Task<City> GetCityByNameAndCountry(string cityName, Guid countryId);

    }
}
