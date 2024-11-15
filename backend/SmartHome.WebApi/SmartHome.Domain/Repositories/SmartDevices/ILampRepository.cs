﻿using SmartHome.Domain.Models.SmartDevices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Domain.Repositories.SmartDevices
{
    public interface ILampRepository
    {
        Task Add(Lamp sensor);
        Task<Lamp> GetById(Guid lampId);
        Task Update(Lamp lamp);

    }
}
