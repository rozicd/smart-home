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
    public class HomeBatteryService : IHomeBatteryService
    {
        private readonly IHomeBatteryRepository _homeBatteryRepository;
        private readonly IMqttClientService _mqttClientService;

        public HomeBatteryService(IHomeBatteryRepository homeBatteryRepository, IMqttClientService mqttClientService)
        {
            _homeBatteryRepository = homeBatteryRepository;
            _mqttClientService = mqttClientService;
        }

        public async Task Add(HomeBattery homeBattery)
        {
            await _homeBatteryRepository.Add(homeBattery);
        }

    }

}
