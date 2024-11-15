﻿using SmartHome.Domain.Models.SmartDevices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Domain.Repositories.SmartDevices
{
    public interface IWashingMachineRepository
    {
        Task Add(WashingMachine sensor);
        Task<List<WashingMachineMode>> GetWashingMachineModes();
        Task<WashingMachine> getById(Guid id);
        Task<WashingMachine> AddScheduledMode(Guid id,  WMScheduledMode mode);


    }
}
