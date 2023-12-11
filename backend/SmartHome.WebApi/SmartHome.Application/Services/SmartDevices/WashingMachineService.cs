﻿using SmartHome.Domain.Models.SmartDevices;
using SmartHome.Domain.Repositories.SmartDevices;
using SmartHome.Domain.Services.SmartDevices;
using SmartHome.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using SmartHome.Domain.Repositories;

namespace SmartHome.Application.Services.SmartDevices
{
    public class WashingMachineService : SmartDeviceService, IWashingMachineService
    {
        private readonly IWashingMachineRepository _washingMachineRepository;

        public WashingMachineService(
            IWashingMachineRepository washingMachineRepository,
            ISmartDeviceRepository smartDeviceRepository,
            IMqttClientService mqttClientService,
            IInfluxClientService influxClientService,
            IServiceScopeFactory scopeFactory)
            : base(smartDeviceRepository, mqttClientService, influxClientService, scopeFactory)
        {
            _washingMachineRepository = washingMachineRepository;
        }

        public async Task Add(WashingMachine washingMachine)
        {
            await _washingMachineRepository.Add(washingMachine);
        }

    }

}
