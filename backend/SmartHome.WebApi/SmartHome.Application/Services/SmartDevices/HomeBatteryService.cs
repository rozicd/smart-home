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
using InfluxDB.Client.Api.Domain;
using InfluxDB.Client.Writes;
using SmartHome.Domain.Models;
using InfluxDB.Client.Core.Flux.Domain;

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
            try
            {
                _mqttClientService.PublishMessageAsync("property/" + homeBattery.PropertyId.ToString() + "/create", homeBattery.Id.ToString() + "," + "HomeBattery").Wait();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            await this.Connect(homeBattery.Id);
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
            await _mqttClientService.PublishMessageAsync(device.Connection + "/info", $"{battery.BatterySize},{battery.BatteryLevel}");
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
                        await SendInfluxDataAsync(device.Id.ToString(), batteryLevel);

                        using (var scope = _scopeFactory.CreateScope())
                        {
                            var serviceProvider = scope.ServiceProvider;

                            var repository = serviceProvider.GetRequiredService<IHomeBatteryRepository>();

                            await repository.UpdateCurrentPower(device.Id, batteryLevel);
                        }



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
        public  async Task<List<FluxTable>> GetInfluxDataAsync(string id, string h)
        {
            string ag = "5s";
            string fn = "last";
            if (h == "1h")
            {
                ag = "5m";
                fn = "mean";

            }
            if (h == "6h")
            {
                ag = "30m";
                fn = "mean";

            }
            if (h == "12h" || h == "24h")
            {
                ag = "1h";
                fn = "mean";

            }
            if (h == "7d" || h == "30d")
            {
                ag = "1d";
                fn = "mean";

            }
            string query = $@"
            from(bucket: ""bucket"")
              |> range(start: -{h}) 
              |> filter(fn: (r) => r[""_measurement""] == ""Energy"")
              |> filter(fn: (r) => r[""_field""] == ""energy"")
              |> filter(fn: (r) => r[""id""] == ""{id}"")
              |> aggregateWindow(every: {ag}, fn: {fn}, createEmpty: false)";



            var result = await _influxClientService.GetInfluxData(query);


            return result;
        }
        public async Task<List<FluxTable>> GetInfluxDataDateRangeAsync(string id, DateTime startDate, DateTime endDate)
        {
            string start = startDate.ToString("yyyy-MM-ddTHH:mm:ssZ");
            string end = endDate.ToString("yyyy-MM-ddTHH:mm:ssZ");
            int daysApart = Math.Abs((endDate - startDate).Days);

            string ag = "1h";

            if (daysApart > 3)
            {
                ag = "6h";
            }
            if (daysApart > 7)
            {
                ag = "1d";
            }

            string query = $@"
            from(bucket: ""bucket"")
              |> range(start: {start},stop:{end} ) 
              |> filter(fn: (r) => r[""_measurement""] == ""Energy"")
              |> filter(fn: (r) => r[""_field""] == ""energy"")
              |> filter(fn: (r) => r[""id""] == ""{id}"")
              |> aggregateWindow(every: {ag}, fn: mean, createEmpty: false)";

            var result = await _influxClientService.GetInfluxData(query);

            return result;
        }

        private async Task SendInfluxDataAsync(string id, float energy)
        {
            var point = PointData
                          .Measurement("Energy")
                          .Tag("id",id)
                          .Field("energy", energy)
                          .Timestamp(DateTime.UtcNow, WritePrecision.Ns);
            await _influxClientService.WriteDataAsync(point);
        }
    }

   }
