using SmartHome.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Domain.Services
{
    public interface ICityService
    {
        Task AddCity(City city);
        Task<IEnumerable<City>> GetAllCities();
        Task<City> GetCityByName(string name);
        Task<City> GetCityById(Guid id);
    }
}
