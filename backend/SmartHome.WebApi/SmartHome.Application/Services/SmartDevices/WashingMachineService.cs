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
    public class WashingMachineService : SmartDeviceService, IWashingMachineService
    {
        private readonly IWashingMachineRepository _washingMachineRepository;

        public WashingMachineService(
            IWashingMachineRepository washingMachineRepository,
            ISmartDeviceRepository smartDeviceRepository,
            IMqttClientService mqttClientService,
            IInfluxClientService influxClientService,
            IServiceScopeFactory scopeFactory)
            : base(smartDeviceRepository, mqttClientService, influxClientService, scopeFactory)
        {
            _washingMachineRepository = washingMachineRepository;
        }

        public async Task Add(WashingMachine washingMachine)
        {
            washingMachine.Id = Guid.NewGuid();
            washingMachine.Connection = "property/" + washingMachine.PropertyId + "/device/" + washingMachine.Id;
            await _washingMachineRepository.Add(washingMachine);
            _mqttClientService.PublishMessageAsync("property/" + washingMachine.PropertyId.ToString() + "/create", washingMachine.Id.ToString() + "," + "WashingMachine").Wait();
            Thread.Sleep(1000);
            await this.Connect(washingMachine.Id);
        }

    }

}
