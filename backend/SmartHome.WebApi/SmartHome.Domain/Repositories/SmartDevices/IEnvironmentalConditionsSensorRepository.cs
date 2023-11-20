using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SmartHome.Domain.Models.SmartDevices;
using SmartHome.Domain.Repositories;

public interface IEnvironmentalConditionsSensorRepository 
{
    Task Add(EnvironmentalConditionsSensor device);
    Task<EnvironmentalConditionsSensor> GetById(Guid id);

}
