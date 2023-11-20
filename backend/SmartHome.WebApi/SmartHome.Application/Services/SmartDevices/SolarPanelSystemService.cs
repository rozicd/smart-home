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
    public class SolarPanelSystemService : ISolarPanelSystemService
    {
        private readonly ISolarPanelSystemRepository _solarPanelSystemRepository;
        private readonly IMqttClientService _mqttClientService;

        public SolarPanelSystemService(ISolarPanelSystemRepository solarPanelSystemRepository, IMqttClientService mqttClientService)
        {
            _solarPanelSystemRepository = solarPanelSystemRepository;
            _mqttClientService = mqttClientService;
        }

        public async Task Add(SolarPanelSystem solarPanelSystem)
        {
            await _solarPanelSystemRepository.Add(solarPanelSystem);
        }

    }

}
