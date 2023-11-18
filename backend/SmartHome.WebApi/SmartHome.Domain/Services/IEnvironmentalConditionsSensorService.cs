using SmartHome.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Domain.Services
{
    public interface IEnvironmentalConditionsSensorService 
    {
        Task Add(EnvironmentalConditionsSensor sensor);
        Task<EnvironmentalConditionsSensor> GetById(Guid id);


    }
}
