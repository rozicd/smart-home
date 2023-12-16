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
using Microsoft.AspNetCore.SignalR;
using SmartHome.Application.Hubs;

namespace SmartHome.Application.Services.SmartDevices
{
    public class CarChargerService : SmartDeviceService, ICarChargerService
    {
        private readonly ICarChargerRepository _carChargerRepository;

        public CarChargerService(
            ICarChargerRepository carChargerRepository,
            ISmartDeviceRepository smartDeviceRepository,
            IMqttClientService mqttClientService,
            IInfluxClientService influxClientService,
            IServiceScopeFactory scopeFactory)
            : base(smartDeviceRepository, mqttClientService, influxClientService, scopeFactory)
        {
            _carChargerRepository = carChargerRepository;
            
        }

        public async Task Add(CarCharger carCharger)
        {
            carCharger.Id = Guid.NewGuid();
            carCharger.Connection = "property/" + carCharger.PropertyId + "/device/" + carCharger.Id;
            await _carChargerRepository.Add(carCharger);
        }

      

    }

}
