using SmartHome.Domain.Models.SmartDevices;
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
    public class HomeBatteryService : SmartDeviceService, IHomeBatteryService
    {
        private readonly IHomeBatteryRepository _homeBatteryRepository;

        public HomeBatteryService(
            IHomeBatteryRepository homeBatteryRepository,
            ISmartDeviceRepository smartDeviceRepository,
            IMqttClientService mqttClientService,
            IInfluxClientService influxClientService,
            IServiceScopeFactory scopeFactory)
            : base(smartDeviceRepository, mqttClientService, influxClientService, scopeFactory)
        {
            _homeBatteryRepository = homeBatteryRepository;
        }

        public async Task Add(HomeBattery homeBattery)
        {
            await _homeBatteryRepository.Add(homeBattery);
        }

    }

}
