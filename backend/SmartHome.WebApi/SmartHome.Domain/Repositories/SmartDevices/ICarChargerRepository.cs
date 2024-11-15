﻿using SmartHome.Domain.Models.SmartDevices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Domain.Repositories.SmartDevices
{
    public interface ICarChargerRepository
    {
        Task Add(CarCharger sensor);
        Task<CarCharger> GetById(Guid id);


    }
}
