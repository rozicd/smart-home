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
    public class SprinklerService : ISprinklerService
    {
        private readonly ISprinklerRepository _sprinklerRepository;
        private readonly IMqttClientService _mqttClientService;

        public SprinklerService(ISprinklerRepository sprinklerRepository, IMqttClientService mqttClientService)
        {
            _sprinklerRepository = sprinklerRepository;
            _mqttClientService = mqttClientService;
        }

        public async Task Add(Sprinkler sprinkler)
        {
            await _sprinklerRepository.Add(sprinkler);
        }

    }

}
