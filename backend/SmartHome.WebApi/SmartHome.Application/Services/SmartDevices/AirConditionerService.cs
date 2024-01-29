using SmartHome.Domain.Models.SmartDevices;
using SmartHome.Domain.Repositories.SmartDevices;
using SmartHome.Domain.Services.SmartDevices;
using SmartHome.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartHome.Domain.Repositories;
using Microsoft.Extensions.DependencyInjection;
using SmartHome.Domain.Models;
using InfluxDB.Client.Writes;
using InfluxDB.Client.Api.Domain;
using Microsoft.AspNetCore.SignalR;
using SmartHome.Application.Hubs;
using System.Reflection.Metadata;
using Newtonsoft.Json;
using InfluxDB.Client.Core.Flux.Domain;

namespace SmartHome.Application.Services.SmartDevices
{
    public class AirConditionerService : SmartDeviceService, IAirConditionerService
    {
        private readonly IAirConditionerRepository _airConditionerRepository;
        private readonly IHubContext<ACHub> _hubContext;

        public AirConditionerService(
            IAirConditionerRepository airConditionerRepository,
            ISmartDeviceRepository smartDeviceRepository,
            IMqttClientService mqttClientService,
            IInfluxClientService influxClientService,
            IHubContext<ACHub> hubContext,
        IServiceScopeFactory scopeFactory)
            : base(smartDeviceRepository, mqttClientService, influxClientService, scopeFactory)
        {
            _airConditionerRepository = airConditionerRepository;
            _hubContext = hubContext;
        }

        public async Task Add(AirConditioner airConditioner)
        {
            airConditioner.Id = Guid.NewGuid();
            airConditioner.Connection = "property/" + airConditioner.PropertyId + "/device/" + airConditioner.Id;
            await _airConditionerRepository.Add(airConditioner);
            _mqttClientService.PublishMessageAsync("property/" + airConditioner.PropertyId.ToString() + "/create", airConditioner.Id.ToString() + "," + "AirConditioner").Wait();
            Thread.Sleep(1000);
            await this.Connect(airConditioner.Id);
        }

        public async Task ChangeMode(LoggedUser user,AirConditioner airConditioner)
        {
            await SaveAndPublishChanges(airConditioner, "/modeChange");
            await SendInfluxDataAsync(airConditioner, airConditioner.CurrentTemperature, airConditioner.Mode, user);
        }

        public Task<AirConditioner> GetById(Guid id)
        {
            return _airConditionerRepository.GetById(id);
        }

        override public async Task<SmartDevice> Connect(Guid id)
        {
            SmartDevice device = await base.Connect(id);

            Console.WriteLine("U Klimi");
            AirConditioner airConditioner;
            using (var scope = _scopeFactory.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;

                var repository = serviceProvider.GetRequiredService<IAirConditionerRepository>();

                airConditioner = await repository.GetById(device.Id);
            }

            await _mqttClientService.PublishMessageAsync(device.Connection + "/info", $"{airConditioner.CurrentTemperature}, {airConditioner.EnergySpending}");
            string deviceTopic = device.Connection + "/ac";
            var client = await _mqttClientService.SubscribeAsync(deviceTopic.ToLower());
            Console.Write("TOPIC:::::" + device.Connection + "/ac");
            client.ApplicationMessageReceivedAsync += async e =>
            {
                string receivedTopic = e.ApplicationMessage.Topic;
                Console.WriteLine("RECIVED TOPIC ::::::" + receivedTopic);
                if (receivedTopic == deviceTopic.ToLower())
                {
                    Console.WriteLine("##############");
                    Console.Write("U KlAJMU SAM");
                    Console.WriteLine("##############");
                    Console.Write(Encoding.UTF8.GetString(e.ApplicationMessage.Payload));
                    string payload = Encoding.UTF8.GetString(e.ApplicationMessage.Payload);
                    string[] payloadParts = payload.Split(',');

                    if (payloadParts.Length == 3)
                    {
                        Console.Write("USAO GDE TREBA");
                        if (float.TryParse(payloadParts[0], out float currentTemperature) && int.TryParse(payloadParts[1], out int powerState))
                        {
                            string acMode = payloadParts[2];
                            Console.WriteLine($"CURRENT AC TEMP: {currentTemperature}");
                            Console.WriteLine($"Power State: {powerState}");
                            Console.WriteLine($"AC Mode: {acMode}");
                            Console.WriteLine(device.Connection);
                            var payloadObject = new { CurrentTemperature = currentTemperature, PowerState = powerState, ACMode = acMode };
                            await _hubContext.Clients.All.SendAsync(device.Connection, payloadObject);

                        }
                        else
                        {
                            Console.WriteLine("Invalid format");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid payload format");
                    }
                }
            };



            return airConditioner;
        }

        public async Task TurnOff(Guid airConditionId)
        {
            var ac = await _airConditionerRepository.GetById(airConditionId);
            await _mqttClientService.PublishMessageAsync(ac.Connection + "/turnOff", $"off");
        }

        public async Task TurnOn(Guid airConditionId)
        {
            var ac = await _airConditionerRepository.GetById(airConditionId);
            await _mqttClientService.PublishMessageAsync(ac.Connection + "/turnOn", $"on");
        }

        private async Task SaveAndPublishChanges(AirConditioner ac, string topic)
        {
            await _airConditionerRepository.Update(ac);
            var serializedScheduledModes = JsonConvert.SerializeObject(ac.ScheduledModes);
            await _mqttClientService.PublishMessageAsync(ac.Connection + topic, $"{ac.CurrentTemperature}, {ac.Mode}, {serializedScheduledModes}");
        }

        private async Task SendInfluxDataAsync(AirConditioner ac, float currentTemperature, ACMode mode, LoggedUser user)
        {
            var point = PointData
                          .Measurement("AC actions")
                          .Tag("Id", ac.Id.ToString())
                          .Field("currentTemp", currentTemperature)
                          .Field("mode", mode.ToString())
                          .Field("user", user.Name)
                          .Field("userId", user.UserId)
                          .Timestamp(DateTime.UtcNow, WritePrecision.Ns);
            await _influxClientService.WriteDataAsync(point);
        }

        public async Task<AirConditioner> AddScheduledMode(Guid id, ACScheduledMode scheduledMode, LoggedUser user)
        {
            AirConditioner ac = await _airConditionerRepository.AddACScheduledMode(id, scheduledMode);
            var serializedScheduledModes = JsonConvert.SerializeObject(ac.ScheduledModes);
            await _mqttClientService.PublishMessageAsync(ac.Connection + "/schedule", $"{serializedScheduledModes}");
            await SendInfluxDataAsync(ac, ac.CurrentTemperature, ACMode.AUTOMATIC, user);
            return ac;
        }
        public async Task<List<FluxTable>> GetInfluxDataDateRangeAsync(string id, DateTime startDate, DateTime endDate)
        {
            string start = startDate.ToString("yyyy-MM-ddTHH:mm:ssZ");
            string end = endDate.ToString("yyyy-MM-ddTHH:mm:ssZ");

            string query = $"from(bucket: \"bucket\")" +
                           $"|> range(start: {start}, stop: {end})" +
                           $"|> filter(fn: (r) => r._measurement == \"AC actions\")" +
                           $"|> filter(fn: (r) => r[\"Id\"] == \"{id}\")"+
                           $"|> sort(columns: [\"_time\"], desc: false)" +
                           $"|> pivot(rowKey: [\"_time\"], columnKey: [\"_field\"], valueColumn: \"_value\")";

            var result = await _influxClientService.GetInfluxData(query);

            return result;

        }

        public async Task<List<FluxTable>> GetInfluxDataAsync(string id, string h)
        {
            string query = $"from(bucket: \"bucket\")" +
                   $"|> range(start: -{h})" +
                   $"|> filter(fn: (r) => r._measurement == \"{"AC actions"}\" and r.Id == \"{id}\")" +
                   $"|> sort(columns: [\"_time\"], desc: false)";
            var result = await _influxClientService.GetInfluxData(query);


            return result;
        }
    }
    
}
