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
using SmartHome.Domain.Models;
using InfluxDB.Client.Api.Domain;
using InfluxDB.Client.Writes;
using Microsoft.AspNetCore.SignalR;
using SmartHome.Application.Hubs;
using InfluxDB.Client.Core.Flux.Domain;
using Newtonsoft.Json;

namespace SmartHome.Application.Services.SmartDevices
{
    public class WashingMachineService : SmartDeviceService, IWashingMachineService
    {
        private readonly IWashingMachineRepository _washingMachineRepository;
        private readonly IHubContext<WMHub> _hubContext;

        public WashingMachineService(
            IWashingMachineRepository washingMachineRepository,
            ISmartDeviceRepository smartDeviceRepository,
            IMqttClientService mqttClientService,
            IInfluxClientService influxClientService,
            IServiceScopeFactory scopeFactory,
            IHubContext<WMHub> hubContext)
            : base(smartDeviceRepository, mqttClientService, influxClientService, scopeFactory)
        {
            _washingMachineRepository = washingMachineRepository;
            _hubContext = hubContext;
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

        public async Task<WashingMachine> GetById(Guid id)
        {
            return await _washingMachineRepository.getById(id);
        }

        public async Task<List<WashingMachineMode>> GetWashingMachineModes()
        {
            return await _washingMachineRepository.GetWashingMachineModes();
        }

        public override async Task<SmartDevice> Connect(Guid id)
        {
            SmartDevice device = await base.Connect(id);
            Console.WriteLine("U masini");
            WashingMachine washingMachine;

            using (var scope = _scopeFactory.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;
                var repository = serviceProvider.GetRequiredService<IWashingMachineRepository>();
                washingMachine = await repository.getById(id);
            }

            await _mqttClientService.PublishMessageAsync(device.Connection + "/info", $"{washingMachine.EnergySpending}");
            string deviceTopic = device.Connection + "/wm";
            var client = await _mqttClientService.SubscribeAsync(deviceTopic.ToLower());
            client.ApplicationMessageReceivedAsync += async e =>
            {
                string receivedTopic = e.ApplicationMessage.Topic;

                if (receivedTopic == deviceTopic.ToLower())
                {
                    string payload = Encoding.UTF8.GetString(e.ApplicationMessage.Payload);
                    string[] payloadParts = payload.Split(',');
                    if (payloadParts.Length != 0)
                    {
                        Console.WriteLine("payload1: " + payloadParts[0]);
                        Console.WriteLine("payload2: " +  payloadParts[1]);
                        var payloadObject = new { PowerState = int.Parse(payloadParts[1]), Mode = payloadParts[0] };
                        
                        await _hubContext.Clients.All.SendAsync(device.Connection, payloadObject);
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Payload Format");
                }
            };

            return washingMachine;
        }

        private async Task SendInfluxDataAsync(WashingMachine wm, string mode,  LoggedUser user)
        {
            var point = PointData
                          .Measurement("WM actions")
                          .Tag("Id", wm.Id.ToString())
                          .Field("mode", mode)
                          .Field("user", user.Name)
                          .Field("userId", user.UserId)
                          .Timestamp(DateTime.UtcNow, WritePrecision.Ns);
            await _influxClientService.WriteDataAsync(point);
        }

        public async Task TurnOn(Guid id)
        {
            var wm = await _washingMachineRepository.getById(id);
            Console.Write(wm.Connection);
            await _mqttClientService.PublishMessageAsync(wm.Connection + "/turnOn", "on");
        }

        public async Task TurnOff(Guid id)
        {
            var wm = await _washingMachineRepository.getById(id);
            await _mqttClientService.PublishMessageAsync(wm.Connection + "/turnOff", "off");
        }

        public async Task changeMode(LoggedUser loggedUser, string mode, WashingMachine washingMachine)
        {
            await SendInfluxDataAsync(washingMachine, mode, loggedUser);
            await _mqttClientService.PublishMessageAsync(washingMachine.Connection + "/modeChange", $"{mode}");
        }

        public async Task<List<FluxTable>> GetInfluxDataDateRangeAsync(string id, DateTime startDate, DateTime endDate)
        {
            string start = startDate.ToString("yyyy-MM-ddTHH:mm:ssZ");
            string end = endDate.ToString("yyyy-MM-ddTHH:mm:ssZ");

            string query = $"from(bucket: \"bucket\")" +
                           $"|> range(start: {start}, stop: {end})" +
                           $"|> filter(fn: (r) => r._measurement == \"WM actions\")" +
                           $"|> filter(fn: (r) => r[\"Id\"] == \"{id}\")" +
                           $"|> sort(columns: [\"_time\"], desc: false)" +
                           $"|> pivot(rowKey: [\"_time\"], columnKey: [\"_field\"], valueColumn: \"_value\")";

            var result = await _influxClientService.GetInfluxData(query);

            return result;
        }

        public async Task<WashingMachine> AddScheduledMode(Guid id, WMScheduledMode wmScheduledMode, LoggedUser loggedUser)
        {
            WashingMachine wm = await _washingMachineRepository.AddScheduledMode(id, wmScheduledMode);
            var serializedScheduledModes = JsonConvert.SerializeObject(wm.ScheduledModes);
            await _mqttClientService.PublishMessageAsync(wm.Connection = "/schedule", $"{serializedScheduledModes}");
            await SendInfluxDataAsync(wm, wmScheduledMode + "(Scheduled)", loggedUser);
            return wm;
        }
    }

}
