﻿using SmartHome.Domain.Models.SmartDevices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Domain.Repositories.SmartDevices
{
    public interface IAirConditionerRepository
    {
        Task Add(AirConditioner sensor);
        Task<AirConditioner> GetById(Guid id);
        Task Update(AirConditioner airConditioner);
        Task<AirConditioner> AddACScheduledMode(Guid id, ACScheduledMode scheduledMode);

    }
}
