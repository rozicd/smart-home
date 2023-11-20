using SmartHome.Domain.Models.SmartDevices;
using SmartHome.Domain.Repositories.SmartDevices;
using SmartHome.Domain.Services.SmartDevices;
using SmartHome.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Application.Services.SmartDevices
{
    public class CarGateService : ICarGateService
    {
        private readonly ICarGateRepository _carGateRepository;
        private readonly IMqttClientService _mqttClientService;

        public CarGateService(ICarGateRepository carGateRepository, IMqttClientService mqttClientService)
        {
            _carGateRepository = carGateRepository;
            _mqttClientService = mqttClientService;
        }

        public async Task Add(CarGate carGate)
        {
            await _carGateRepository.Add(carGate);
        }

    }

}
