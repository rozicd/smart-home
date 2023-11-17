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

        public async Task<IEnumerable<EnvironmentalConditionsSensor>> GetSmartDevicesByUserId(Guid userId)
        {
            return await _sensorRepository.GetSmartDevicesByUserId(userId);
        }

        public async Task<EnvironmentalConditionsSensor> GetById(Guid id)
        {
            return await _sensorRepository.GetById(id);
        }

        public async Task Update(EnvironmentalConditionsSensor sensor)
        {
            await _sensorRepository.Update(sensor);
        }

        public async Task Connect(Guid id, string address)
        {
            await _sensorRepository.Connect(id,address);
        }

        public async Task PowerOn(Guid id)
        {

            EnvironmentalConditionsSensor ecs = await GetById(id);
            if (ecs.DeviceStatus == DeviceStatus.ONLINE) return;
            await _mqttClientService.ConnectAsync();
            await _mqttClientService.PublishMessageAsync(ecs.Connection, "PowerOn");
            await _mqttClientService.SubscribeAsync("esc/status");
            ecs.DeviceStatus = DeviceStatus.ONLINE;
            await Update(ecs);


            return;
        }
        public async Task PowerOff(Guid id)
        {
            EnvironmentalConditionsSensor ecs = await GetById(id);
            if (ecs.DeviceStatus == DeviceStatus.OFFLINE) return;
            await _mqttClientService.ConnectAsync();
            await _mqttClientService.PublishMessageAsync(ecs.Connection, "PowerOff");
            await _mqttClientService.UnubscribeAsync("esc/status");
            ecs.DeviceStatus = DeviceStatus.OFFLINE;
            await Update(ecs);


            return;
        }
    }
}
