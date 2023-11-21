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
    public class AirConditionerService : IAirConditionerService
    {
        private readonly IAirConditionerRepository _airConditionerRepository;
        private readonly IMqttClientService _mqttClientService;

        public AirConditionerService(IAirConditionerRepository airConditionerRepository, IMqttClientService mqttClientService)
        {
            _airConditionerRepository = airConditionerRepository;
            _mqttClientService = mqttClientService;
        }

        public async Task Add(AirConditioner airConditioner)
        {
            await _airConditionerRepository.Add(airConditioner);
        }

    }

}
