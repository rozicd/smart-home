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

        public EnvironmentalConditionsSensorService(IEnvironmentalConditionsSensorRepository sensorRepository)
        {
            _sensorRepository = sensorRepository;
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

        public async Task Connect(Guid id)
        {
            await _sensorRepository.Connect(id);
        }
    }
}
