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
    public class CarGateService : SmartDeviceService,ICarGateService
    {
        private readonly ICarGateRepository _carGateRepository;

        public CarGateService(
            ICarGateRepository carGateRepository,
            ISmartDeviceRepository smartDeviceRepository,
            IMqttClientService mqttClientService,
            IInfluxClientService influxClientService,
            IServiceScopeFactory scopeFactory)
            : base(smartDeviceRepository, mqttClientService, influxClientService, scopeFactory)
        {
            _carGateRepository = carGateRepository;
        }

        public async Task Add(CarGate carGate)
        {
            carGate.Id = Guid.NewGuid();
            carGate.Connection = "property/" + carGate.PropertyId + "/device/" + carGate.Id;
            await _carGateRepository.Add(carGate);
        }

    }

}
