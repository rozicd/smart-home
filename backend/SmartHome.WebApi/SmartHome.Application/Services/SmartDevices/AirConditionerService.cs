using SmartHome.Domain.Models.SmartDevices;
using SmartHome.Domain.Repositories.SmartDevices;
using SmartHome.Domain.Services.SmartDevices;
using SmartHome.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartHome.Domain.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace SmartHome.Application.Services.SmartDevices
{
    public class AirConditionerService : SmartDeviceService, IAirConditionerService
    {
        private readonly IAirConditionerRepository _airConditionerRepository;

        public AirConditionerService(
            IAirConditionerRepository airConditionerRepository,
            ISmartDeviceRepository smartDeviceRepository,
            IMqttClientService mqttClientService,
            IInfluxClientService influxClientService,
            IServiceScopeFactory scopeFactory)
            : base(smartDeviceRepository, mqttClientService, influxClientService, scopeFactory)
        {
            _airConditionerRepository = airConditionerRepository;
        }

        public async Task Add(AirConditioner airConditioner)
        {
            airConditioner.Id = Guid.NewGuid();
            airConditioner.Connection = "property/" + airConditioner.PropertyId + "/device/" + airConditioner.Id;
            await _airConditionerRepository.Add(airConditioner);
        }

        public Task<AirConditioner> GetById(Guid id)
        {
            return _airConditionerRepository.GetById(id);
        }
    }

}
