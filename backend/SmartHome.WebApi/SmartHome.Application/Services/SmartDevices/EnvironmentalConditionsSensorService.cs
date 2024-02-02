using InfluxDB.Client.Api.Domain;
using InfluxDB.Client.Core.Flux.Domain;
using InfluxDB.Client.Writes;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection;
using MQTTnet;
using SmartHome.Application.Hubs;
using SmartHome.Domain.Models.SmartDevices;
using SmartHome.Domain.Repositories;
using SmartHome.Domain.Repositories.SmartDevices;
using SmartHome.Domain.Services;
using SmartHome.Domain.Services.SmartDevices;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Application.Services.SmartDevices
{
    public class EnvironmentalConditionsSensorService : SmartDeviceService, IEnvironmentalConditionsSensorService
    {
        private readonly IEnvironmentalConditionsSensorRepository _enviromentalConditionsSensorRepository;
        private readonly IHubContext<ECSHub> _hubContext;

        public EnvironmentalConditionsSensorService(
            IEnvironmentalConditionsSensorRepository enviromentalConditionsSensorRepository,
            ISmartDeviceRepository smartDeviceRepository,
            IMqttClientService mqttClientService,
            IInfluxClientService influxClientService,
            IServiceScopeFactory scopeFactory,
            IHubContext<ECSHub> hubContext)
            : base(smartDeviceRepository, mqttClientService, influxClientService, scopeFactory)
        {
            _enviromentalConditionsSensorRepository = enviromentalConditionsSensorRepository;
            _hubContext = hubContext;
        
        }

        public async Task Add(EnvironmentalConditionsSensor sensor)
        {
            sensor.Id = Guid.NewGuid();
            sensor.Connection = "property/" + sensor.PropertyId + "/device/" + sensor.Id;
            await _enviromentalConditionsSensorRepository.Add(sensor);
            _mqttClientService.PublishMessageAsync("property/" + sensor.PropertyId.ToString() + "/create", sensor.Id.ToString() + "," + "EnvironmentalConditionsSensor").Wait();
            Thread.Sleep(1000);
            await this.Connect(sensor.Id);
        }


        public async Task<EnvironmentalConditionsSensor> GetById(Guid id)
        {
            return await _enviromentalConditionsSensorRepository.GetById(id);
        }

        override public async Task<SmartDevice> Connect(Guid id)
        {
            SmartDevice device = await base.Connect(id);
            Console.WriteLine("U ambijentalnom senzoru");
            EnvironmentalConditionsSensor environmentalConditionsSensor;
            using (var scope = _scopeFactory.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;

                var repository = serviceProvider.GetRequiredService<IEnvironmentalConditionsSensorRepository>();

                environmentalConditionsSensor = await repository.GetById(device.Id);
            }
            Console.WriteLine("KONEKCIJA:");

            Console.WriteLine(device.Connection);
            await _mqttClientService.PublishMessageAsync(device.Connection + "/info", $"{environmentalConditionsSensor.EnergySpending},{environmentalConditionsSensor.AirHumidity},{environmentalConditionsSensor.RoomTemperature}");
            var client = await _mqttClientService.SubscribeAsync(device.Connection + "/environmentalConditionsSensor");
            client.ApplicationMessageReceivedAsync += async e =>
            {
                string recievedTopic = e.ApplicationMessage.Topic;
                Console.WriteLine(recievedTopic);
                if (recievedTopic == device.Connection + "/environmentalConditionsSensor")
                {
                    Console.Write("U SENZORU SAM");
                    string payload = Encoding.UTF8.GetString(e.ApplicationMessage.Payload);
                    string[] payloadParts = payload.Split(',');
                    if(payloadParts.Length == 2)
                    {
                        if (float.TryParse(payloadParts[0], out float airHumidity) && float.TryParse(payloadParts[1], out float roomTemperature))
                        {
                            Console.WriteLine($"RoomTemperature: {roomTemperature} degrees");
                            Console.WriteLine($"AirHumidity: {airHumidity} %");
                            Console.WriteLine(device.Connection);
                            await _hubContext.Clients.All.SendAsync(device.Connection, airHumidity, roomTemperature);
                            await SendInfluxDataAsync(environmentalConditionsSensor, airHumidity, roomTemperature);
                        }
                        else
                        {
                            Console.WriteLine("Invalid senzor values");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid payload format");
                    }
                }
                
            };
            return environmentalConditionsSensor;
        }

        private async Task SendInfluxDataAsync(EnvironmentalConditionsSensor sensor, float airHumidity, float roomTemperature) 
        {
            var point = PointData
              .Measurement("ESC readings")
              .Tag("Id", sensor.Id.ToString())
              .Field("airHumidity", airHumidity)
              .Field("roomTemperature", roomTemperature)
              .Timestamp(DateTime.UtcNow, WritePrecision.Ns);
            await _influxClientService.WriteDataAsync(point);
        }

        public async Task<List<FluxTable>> GetInfluxDataDateRangeAsync(string id, DateTime startDate, DateTime endDate)
        {
            int daysApart = Math.Abs((endDate - startDate).Days);

            string ag = "1h";
            if(daysApart < 1)
            {
                ag = "5s";
            }

            if (daysApart > 3)
            {
                ag = "30m";
            }
            if (daysApart > 7)
            {
                ag = "1h";
            }

            string start = startDate.ToString("yyyy-MM-ddTHH:mm:ssZ");
            string end = endDate.ToString("yyyy-MM-ddTHH:mm:ssZ");
            string query = $"from(bucket: \"bucket\")" +
                           $"|> range(start: {start}, stop: {end})" +
                           $"|> filter(fn: (r) => r._measurement == \"ESC readings\")" +
                           $"|> filter(fn: (r) => r[\"Id\"] == \"{id}\")" +
                           $"|> aggregateWindow(every:{ag}, fn: mean, createEmpty: false)" +
                           $"|> sort(columns: [\"_time\"], desc: false)" +
                           $"|> pivot(rowKey: [\"_time\"], columnKey: [\"_field\"], valueColumn: \"_value\")";

            var result = await _influxClientService.GetInfluxData(query);

            return result;
        }

    }
}
