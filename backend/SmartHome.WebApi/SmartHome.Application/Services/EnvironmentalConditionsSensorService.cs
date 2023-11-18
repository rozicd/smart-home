using MQTTnet;
using SmartHome.Domain.Models;
using SmartHome.Domain.Repositories;
using SmartHome.Domain.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartHome.Application.Services
{
    public class EnvironmentalConditionsSensorService : IEnvironmentalConditionsSensorService
    {
        private readonly IEnvironmentalConditionsSensorRepository _sensorRepository;
        private readonly IMqttClientService _mqttClientService;

        public EnvironmentalConditionsSensorService(IEnvironmentalConditionsSensorRepository sensorRepository, IMqttClientService mqttClientService)
        {
            _sensorRepository = sensorRepository;
            _mqttClientService = mqttClientService;

        }

        public async Task Add(EnvironmentalConditionsSensor sensor)
        {
            await _sensorRepository.Add(sensor);
        }

        

        public async Task<EnvironmentalConditionsSensor> GetById(Guid id)
        {
            return await _sensorRepository.GetById(id);
        }

      
       

        
    }
}
