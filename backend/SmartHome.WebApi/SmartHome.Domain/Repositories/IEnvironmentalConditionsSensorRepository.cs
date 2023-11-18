using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SmartHome.Domain.Models;
using SmartHome.Domain.Repositories;

public interface IEnvironmentalConditionsSensorRepository 
{
    Task Add(EnvironmentalConditionsSensor device);
    Task<EnvironmentalConditionsSensor> GetById(Guid id);

}
