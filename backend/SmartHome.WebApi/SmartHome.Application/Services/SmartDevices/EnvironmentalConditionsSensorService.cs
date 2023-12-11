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
 
            await _enviromentalConditionsSensorRepository.Add(sensor);
        }


        public async Task<EnvironmentalConditionsSensor> GetById(Guid id)
        {
            return await _enviromentalConditionsSensorRepository.GetById(id);
        }





    }
}
