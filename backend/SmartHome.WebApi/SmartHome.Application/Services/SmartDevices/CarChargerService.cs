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
    public class CarChargerService : ICarChargerService
    {
        private readonly ICarChargerRepository _carChargerRepository;
        private readonly IMqttClientService _mqttClientService;

        public CarChargerService(ICarChargerRepository carChargerRepository, IMqttClientService mqttClientService)
        {
            _carChargerRepository = carChargerRepository;
            _mqttClientService = mqttClientService;
        }

        public async Task Add(CarCharger carCharger)
        {
            await _carChargerRepository.Add(carCharger);
        }

    }

}
