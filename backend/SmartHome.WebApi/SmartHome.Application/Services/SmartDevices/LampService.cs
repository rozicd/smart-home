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
using InfluxDB.Client.Api.Domain;
using InfluxDB.Client.Writes;
using Microsoft.AspNetCore.SignalR;
using SmartHome.Application.Hubs;

namespace SmartHome.Application.Services.SmartDevices
{
    public class LampService : SmartDeviceService, ILampService
    {
        private readonly ILampRepository _lampRepository;
        private readonly IHubContext<LampHub> _hubContext;


        public LampService(
            ILampRepository lampRepository,
            ISmartDeviceRepository smartDeviceRepository,
            IMqttClientService mqttClientService,
            IInfluxClientService influxClientService,
            IHubContext<LampHub> hubContext,
            IServiceScopeFactory scopeFactory)
            : base(smartDeviceRepository, mqttClientService, influxClientService, scopeFactory)
        {
            _lampRepository = lampRepository;
            _hubContext = hubContext;
        }

        public async Task Add(Lamp lamp)
        {
            lamp.Id = Guid.NewGuid();
            lamp.Connection = "property/" + lamp.PropertyId + "/device/" + lamp.Id;
            await _lampRepository.Add(lamp);
        }

        public async Task<Lamp> GetById(Guid lampId)
        {
            return await _lampRepository.GetById(lampId);
        }

        override public async Task<SmartDevice> Connect(Guid id)
        {
            SmartDevice device = await base.Connect(id);
            Console.WriteLine("U Lampi");
            Lamp lamp;
            using (var scope = _scopeFactory.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;

                var repository = serviceProvider.GetRequiredService<ILampRepository>();

                lamp = await repository.GetById(device.Id);
            }
            await _mqttClientService.PublishMessageAsync(device.Connection + "/info", $"{lamp.LightThreshold},{lamp.LampMode}");
            var client = await _mqttClientService.SubscribeAsync(device.Connection + "/light");

            client.ApplicationMessageReceivedAsync += async e =>
            {
                string receivedTopic = e.ApplicationMessage.Topic;
                if (receivedTopic == device.Connection + "/light")
                {
                    Console.Write("U LAJTU SAM");
                    Console.Write(Encoding.UTF8.GetString(e.ApplicationMessage.Payload));
                    string payload = Encoding.UTF8.GetString(e.ApplicationMessage.Payload);
                    string[] payloadParts = payload.Split(',');

                    if (payloadParts.Length == 2)
                    {
                        if (float.TryParse(payloadParts[0], out float lightStrength) && int.TryParse(payloadParts[1],out int powerState))
                        {
                            Console.WriteLine($"Light Strength: {lightStrength}");
                            Console.WriteLine($"Power State: {powerState}");
                            Console.WriteLine(device.Connection);
                            await _hubContext.Clients.All.SendAsync(device.Connection, lightStrength, powerState);

                            await SendInfluxDataAsync(lamp, lightStrength, powerState);
                        }
                        else
                        {
                            Console.WriteLine("Invalid light strength format");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid payload format");
                    }
                }
            };
            return lamp;
        }

        private async Task SendInfluxDataAsync(Lamp lamp, float currentLight, int powerState)
        {
            var point = PointData
                          .Measurement(lamp.Name)
                          .Field("light", currentLight)
                          .Field("power", powerState)
                          .Timestamp(DateTime.UtcNow, WritePrecision.Ns);
            await _influxClientService.WriteDataAsync(point);
        }

    }

}
