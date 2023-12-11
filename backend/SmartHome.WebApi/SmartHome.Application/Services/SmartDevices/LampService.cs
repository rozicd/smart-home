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
    public class LampService : SmartDeviceService, ILampService
    {
        private readonly ILampRepository _lampRepository;

        public LampService(
            ILampRepository lampRepository,
            ISmartDeviceRepository smartDeviceRepository,
            IMqttClientService mqttClientService,
            IInfluxClientService influxClientService,
            IServiceScopeFactory scopeFactory)
            : base(smartDeviceRepository, mqttClientService, influxClientService, scopeFactory)
        {
            _lampRepository = lampRepository;
        }

        public async Task Add(Lamp lamp)
        {
            await _lampRepository.Add(lamp);
        }

        override public async Task TurnOn(Guid id)
        {
            await base.TurnOn(id);
            Console.WriteLine("U LAMPI SAM");
            return;
        }

    }

}
