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
    public class SolarPanelSystemService : SmartDeviceService, ISolarPanelSystemService
    {
        private readonly ISolarPanelSystemRepository _solarPanelSystemRepository;

        public SolarPanelSystemService(
            ISolarPanelSystemRepository solarPanelSystemRepository,
            ISmartDeviceRepository smartDeviceRepository,
            IMqttClientService mqttClientService,
            IInfluxClientService influxClientService,
            IServiceScopeFactory scopeFactory)
            : base(smartDeviceRepository, mqttClientService, influxClientService, scopeFactory)
        {
            _solarPanelSystemRepository = solarPanelSystemRepository;
        }

        public async Task Add(SolarPanelSystem solarPanelSystem)
        {
            await _solarPanelSystemRepository.Add(solarPanelSystem);
        }
        public async Task<SolarPanelSystem> GetById(Guid id)
        {
            return await _solarPanelSystemRepository.GetById(id);
        }
        override public async Task TurnOff(Guid id)

        {
            await base.TurnOff(id);
        }


        override public async Task<SmartDevice> TurnOn(Guid id)
        {
            SmartDevice device = await base.TurnOn(id);
            Console.WriteLine("U Panelu");
            SolarPanelSystem sps = await GetById(device.Id);
            await _mqttClientService.PublishMessageAsync(device.Connection + "/info", $"{sps.NumberOfPanels},{sps.Size},{sps.Efficiency}");
            var client = await _mqttClientService.SubscribeAsync(device.Connection + "/power");
            if (!topics.Contains(device.Connection + "/power"))
            {
                topics.Add(device.Connection + "/power");
            }
            if (!topics.Contains(device.Connection + "/info"))
            {
                topics.Add(device.Connection + "/info");
            }

            client.ApplicationMessageReceivedAsync += e =>
            {

                string receivedTopic = e.ApplicationMessage.Topic;
                if (receivedTopic == device.Connection + "/power")
                {
                    Console.WriteLine("MASANKURAC");
                }
                return Task.CompletedTask;
            };


            return device;
        }

    }

}
