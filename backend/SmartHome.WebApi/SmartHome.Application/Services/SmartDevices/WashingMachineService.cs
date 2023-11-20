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
    public class WashingMachineService : IWashingMachineService
    {
        private readonly IWashingMachineRepository _washingMachineRepository;
        private readonly IMqttClientService _mqttClientService;

        public WashingMachineService(IWashingMachineRepository washingMachineRepository, IMqttClientService mqttClientService)
        {
            _washingMachineRepository = washingMachineRepository;
            _mqttClientService = mqttClientService;
        }

        public async Task Add(WashingMachine washingMachine)
        {
            await _washingMachineRepository.Add(washingMachine);
        }

    }

}
