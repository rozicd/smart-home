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
    public class SprinklerService : SmartDeviceService, ISprinklerService
    {
        private readonly ISprinklerRepository _sprinklerRepository;

        public SprinklerService(
            ISprinklerRepository sprinklerRepository,
            ISmartDeviceRepository smartDeviceRepository,
            IMqttClientService mqttClientService,
            IInfluxClientService influxClientService,
            IServiceScopeFactory scopeFactory)
            : base(smartDeviceRepository, mqttClientService, influxClientService, scopeFactory)
        {
            _sprinklerRepository = sprinklerRepository;
        }

        public async Task Add(Sprinkler sprinkler)
        {
            sprinkler.Id = Guid.NewGuid();
            sprinkler.Connection = "property/" + sprinkler.PropertyId + "/device/" + sprinkler.Id;
            await _sprinklerRepository.Add(sprinkler);
            _mqttClientService.PublishMessageAsync("property/" + sprinkler.PropertyId.ToString() + "/create", sprinkler.Id.ToString() + "," + "Sprinkler").Wait();
            Thread.Sleep(1000);
            await this.Connect(sprinkler.Id);
        }

    }

}
