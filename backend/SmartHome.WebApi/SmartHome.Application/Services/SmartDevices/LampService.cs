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
    public class LampService : ILampService
    {
        private readonly ILampRepository _lampRepository;
        private readonly IMqttClientService _mqttClientService;

        public LampService(ILampRepository lampRepository, IMqttClientService mqttClientService)
        {
            _lampRepository = lampRepository;
            _mqttClientService = mqttClientService;
        }

        public async Task Add(Lamp lamp)
        {
            await _lampRepository.Add(lamp);
        }

    }

}
