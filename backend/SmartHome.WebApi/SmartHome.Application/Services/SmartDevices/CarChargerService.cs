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
using System.Reactive.Joins;
using InfluxDB.Client.Api.Domain;
using InfluxDB.Client.Writes;
using SmartHome.Domain.Models;

namespace SmartHome.Application.Services.SmartDevices
{
    public class CarChargerService : SmartDeviceService, ICarChargerService
    {
        private readonly ICarChargerRepository _carChargerRepository;
        private readonly IHubContext<CarChargerHub> _hubContext;

        public CarChargerService(
            ICarChargerRepository carChargerRepository,
            ISmartDeviceRepository smartDeviceRepository,
            IMqttClientService mqttClientService,
            IInfluxClientService influxClientService,
            IServiceScopeFactory scopeFactory,
            IHubContext<CarChargerHub> hubContext)
            : base(smartDeviceRepository, mqttClientService, influxClientService, scopeFactory)
        {
            _carChargerRepository = carChargerRepository;
            _hubContext = hubContext;
        }

        public async Task Add(CarCharger carCharger)
        {
            carCharger.Id = Guid.NewGuid();
            carCharger.Connection = "property/" + carCharger.PropertyId + "/device/" + carCharger.Id;
            await _carChargerRepository.Add(carCharger);
            _mqttClientService.PublishMessageAsync("property/" + carCharger.PropertyId.ToString() + "/create", carCharger.Id.ToString() + "," + "CarCharger").Wait();
            Thread.Sleep(1000);
            await this.Connect(carCharger.Id);
        }
        public async Task<CarCharger> GetById(Guid chargerId)
        {
            return await _carChargerRepository.GetById(chargerId);
        }
        public override async Task<SmartDevice> Connect(Guid id)
        {
            SmartDevice device = await  base.Connect(id);
            CarCharger carCharger;
            using (var scope = _scopeFactory.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;
                var repository = serviceProvider.GetRequiredService<ICarChargerRepository>();
                carCharger = await repository.GetById(device.Id);
            }
            await _mqttClientService.PublishMessageAsync(device.Connection + "/info", $"{carCharger.ChargingPower},{carCharger.ConnectorNumber}");
            string pluggedTipic = device.Connection + "/plugged";
            var client = await _mqttClientService.SubscribeAsync(pluggedTipic);

            client.ApplicationMessageReceivedAsync += async e =>
            {

                string receivedTopic = e.ApplicationMessage.Topic;
                if (receivedTopic == pluggedTipic)
                {
                    Console.WriteLine("PLUGGED");
                  

                    Console.Write(Encoding.UTF8.GetString(e.ApplicationMessage.Payload));
                    string payload = Encoding.UTF8.GetString(e.ApplicationMessage.Payload);
                    await _hubContext.Clients.All.SendAsync(device.Connection, payload);
                    string[] values = payload.Split(':');
                    await SendChargerInfluxDataAsync(device.Id.ToString(), values[0],float.Parse(values[1]));
                    await SendInfluxDataAsync("System", device.Id.ToString(), values[0], float.Parse(values[1]));



                }
            };
            for (int i = 0;i<carCharger.ConnectorNumber;i++)
            {
                string plugTopic = device.Connection + "/"+i;

                Console.WriteLine(plugTopic);


                await _mqttClientService.SubscribeAsync(plugTopic);

                client.ApplicationMessageReceivedAsync += async e =>
                {
                    int index = i;
                    string receivedTopic = e.ApplicationMessage.Topic;
                    if (receivedTopic == plugTopic)
                    {
                        Console.WriteLine("Battery");


                        Console.Write(Encoding.UTF8.GetString(e.ApplicationMessage.Payload));
                        string payload = Encoding.UTF8.GetString(e.ApplicationMessage.Payload);
                        string[] values = payload.Split(',');
                        await _hubContext.Clients.All.SendAsync(values[0], values[1]);


                    }
                };
            }

            return device;
        }

        public async Task ChangeTreshold(Guid id, string plug, float treshold, string user)
        {
            CarCharger charger = await  _carChargerRepository.GetById(id);
            string topic = charger.Connection + "/" + plug + "/treshold";
            await _mqttClientService.PublishMessageAsyncNoRetain(topic,treshold.ToString());
            await SendInfluxDataAsync(user, id.ToString(), "treshold", treshold);
        }
        private async Task SendChargerInfluxDataAsync(string id, string action,float power)
        {
            string fieldName = "spent";
            if (action == "connected")
            {
                fieldName = "plug";
            }
            var point = PointData
                          .Measurement("Car Charger")
                          .Tag("id", id)
                          .Tag("action", action)
                          .Field(fieldName, power)
                          .Timestamp(DateTime.UtcNow, WritePrecision.Ns);
            await _influxClientService.WriteDataAsync(point);
        }
        private async Task SendInfluxDataAsync(string user, string id, string action,float value)
        {
            string fieldName = "plug";
            if (action == "treshold")
            {
                fieldName = "value";
            }
            var point = PointData
                          .Measurement("Charger Actions")
                          .Tag("id", id)
                          .Tag("user", user)
                          .Tag("action", action)
                          .Field(fieldName, value)
                          .Timestamp(DateTime.UtcNow, WritePrecision.Ns);
            await _influxClientService.WriteDataAsync(point);
        }

    }


}
