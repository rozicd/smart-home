using Microsoft.Extensions.DependencyInjection;
using MQTTnet;
using SmartHome.Domain.Models.SmartDevices;
using SmartHome.Domain.Repositories;
using SmartHome.Domain.Repositories.SmartDevices;
using SmartHome.Domain.Services;
using SmartHome.Domain.Services.SmartDevices;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartHome.Application.Services.SmartDevices
{
    public class EnvironmentalConditionsSensorService : SmartDeviceService, IEnvironmentalConditionsSensorService
    {
        private readonly IEnvironmentalConditionsSensorRepository _enviromentalConditionsSensorRepository;

        public EnvironmentalConditionsSensorService(
            IEnvironmentalConditionsSensorRepository enviromentalConditionsSensorRepository,
            ISmartDeviceRepository smartDeviceRepository,
            IMqttClientService mqttClientService,
            IInfluxClientService influxClientService,
            IServiceScopeFactory scopeFactory)
            : base(smartDeviceRepository, mqttClientService, influxClientService, scopeFactory)
        {
            _enviromentalConditionsSensorRepository = enviromentalConditionsSensorRepository;
        }

        public async Task Add(EnvironmentalConditionsSensor sensor)
        {
            sensor.Id = Guid.NewGuid();
            sensor.Connection = "property/" + sensor.PropertyId + "/device/" + sensor.Id;
            await _enviromentalConditionsSensorRepository.Add(sensor);
            _mqttClientService.PublishMessageAsync("property/" + sensor.PropertyId.ToString() + "/create", sensor.Id.ToString() + "," + "EnvironmentalConditionsSensor").Wait();
            Thread.Sleep(1000);
            await this.Connect(sensor.Id);
        }


        public async Task<EnvironmentalConditionsSensor> GetById(Guid id)
        {
            return await _enviromentalConditionsSensorRepository.GetById(id);
        }





    }
}
