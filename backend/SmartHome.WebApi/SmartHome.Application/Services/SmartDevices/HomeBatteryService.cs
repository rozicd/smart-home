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
    public class HomeBatteryService : SmartDeviceService, IHomeBatteryService
    {
        private readonly IHomeBatteryRepository _homeBatteryRepository;
        private readonly IHubContext<HomeBatteryHub> _hubContext;

        public HomeBatteryService(
            IHomeBatteryRepository homeBatteryRepository,
            ISmartDeviceRepository smartDeviceRepository,
            IMqttClientService mqttClientService,
            IInfluxClientService influxClientService,
            IServiceScopeFactory scopeFactory,
            IHubContext<HomeBatteryHub> hubContext
            )
            : base(smartDeviceRepository, mqttClientService, influxClientService, scopeFactory)
        {
            _homeBatteryRepository = homeBatteryRepository;
            _hubContext = hubContext;
        }

        public async Task Add(HomeBattery homeBattery)
        {
            homeBattery.Id = Guid.NewGuid();
            homeBattery.Connection = "property/" + homeBattery.PropertyId + "/device/" + homeBattery.Id;
            await _homeBatteryRepository.Add(homeBattery);
        }
        override public async Task<SmartDevice> Connect(Guid id)
        {
            SmartDevice device = await base.Connect(id);
            Console.WriteLine("U Bateriji");
            HomeBattery battery;
            using (var scope = _scopeFactory.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;

                var repository = serviceProvider.GetRequiredService<IHomeBatteryRepository>();

                battery = await repository.GetById(device.Id);
            }
            await _mqttClientService.PublishMessageAsync(device.Connection + "/info", $"{battery.BatterySize}");
            string batteryTopic = device.Connection + "/battery_level";
            Console.WriteLine(batteryTopic);
            var client = await _mqttClientService.SubscribeAsync(batteryTopic);

             client.ApplicationMessageReceivedAsync += async e =>
            {

                string receivedTopic = e.ApplicationMessage.Topic;
                if (receivedTopic == batteryTopic)
                {
                    Console.WriteLine("DENIS");

                    Console.Write(Encoding.UTF8.GetString(e.ApplicationMessage.Payload));
                    string payload = Encoding.UTF8.GetString(e.ApplicationMessage.Payload);
                    if (float.TryParse(payload, out float batteryLevel))
                    {
                        await _hubContext.Clients.All.SendAsync(device.Connection, batteryLevel);
                    

                    }
                    else
                    {
                        Console.WriteLine("Invalid battery Level  format");
                    }

                }
            };



            return device;

        }

        public async Task<HomeBattery> GetById(Guid id)
        {
            return await _homeBatteryRepository.GetById(id);
        }
    }

   }
