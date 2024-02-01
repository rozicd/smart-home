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
using InfluxDB.Client.Core.Flux.Domain;
using InfluxDB.Client.Api.Domain;
using InfluxDB.Client.Writes;
using static SmartHome.Domain.Models.SmartDevices.CarGate;
using Microsoft.AspNetCore.SignalR;
using SmartHome.Application.Hubs;
using static System.Collections.Specialized.BitVector32;
using Microsoft.AspNetCore.Http.HttpResults;

namespace SmartHome.Application.Services.SmartDevices
{
    public class SprinklerService : SmartDeviceService, ISprinklerService
    {
        private readonly ISprinklerRepository _sprinklerRepository;
        private readonly IHubContext<SprinklerHub> _hubContext;

        public SprinklerService(
            ISprinklerRepository sprinklerRepository,
            ISmartDeviceRepository smartDeviceRepository,
            IMqttClientService mqttClientService,
            IHubContext<SprinklerHub> hubContext,
            IInfluxClientService influxClientService,
            IServiceScopeFactory scopeFactory)
            : base(smartDeviceRepository, mqttClientService, influxClientService, scopeFactory)
        {
            _hubContext = hubContext;
            _sprinklerRepository = sprinklerRepository;
        }
        public async Task<Sprinkler> GetById(Guid sprinklerId)
        {
            return await _sprinklerRepository.GetByIdAsync(sprinklerId);
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

        override public async Task<SmartDevice> Connect(Guid id)
        {
            SmartDevice device = await base.Connect(id);
            Console.WriteLine("U CarGate");
            Sprinkler sprinkler;
            using (var scope = _scopeFactory.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;

                var repository = serviceProvider.GetRequiredService<ISprinklerRepository>();

                sprinkler = await repository.GetByIdAsync(device.Id);
            }
            string schedulesString = string.Join(",", (await _sprinklerRepository.GetSprinklerSchedulesAsync(sprinkler.Id)).Select(s => $"{s.Id}:-:{s.StartTime}:-:{s.DurationMinutes}"));
            await _mqttClientService.PublishMessageAsync(device.Connection + "/info", $"{sprinkler.Power},{sprinkler.EnergySpending},{schedulesString}");
            var client = await _mqttClientService.SubscribeAsync(device.Connection + "/powerStatus");
            client.ApplicationMessageReceivedAsync += async e =>
            {
                string receivedTopic = e.ApplicationMessage.Topic;
                if (receivedTopic == device.Connection + "/powerStatus")
                {
                    string payload = Encoding.UTF8.GetString(e.ApplicationMessage.Payload);
                    string[] payloadParts = payload.Split(',');
                    if(int.TryParse(payloadParts[0], out int powerState))
                    {

                        await _hubContext.Clients.All.SendAsync(device.Connection + "/power", powerState);
                    }
                }
            };


            var actionClient = await _mqttClientService.SubscribeAsync(device.Connection + "/action");

            actionClient.ApplicationMessageReceivedAsync += async e =>
            {
                string receivedTopic = e.ApplicationMessage.Topic;
                if (receivedTopic == device.Connection + "/action")
                {
                    Console.Write("U ACTIONU SAM");
                    Console.Write(Encoding.UTF8.GetString(e.ApplicationMessage.Payload));
                    string payload = Encoding.UTF8.GetString(e.ApplicationMessage.Payload);
                    string[] payloadParts = payload.Split(',');

                    if (payloadParts.Length == 2)
                    {
                        string didAction = payloadParts[0];
                        string action = payloadParts[1];
                        if (action == "1")
                        {
                            action = "Sprinkler turned on";
                            sprinkler.Power = true;
                            using (var scope = _scopeFactory.CreateScope())
                            {
                                var serviceProvider = scope.ServiceProvider;

                                var repository = serviceProvider.GetRequiredService<ISprinklerRepository>();

                                await repository.UpdateAsync(sprinkler);
                            }
                            await _hubContext.Clients.All.SendAsync(device.Connection + "/power", true);
                        }
                        else if (action == "2")
                        {
                            action = "Sprinkler turned off";
                            sprinkler.Power = false;
                            using (var scope = _scopeFactory.CreateScope())
                            {
                                var serviceProvider = scope.ServiceProvider;

                                var repository = serviceProvider.GetRequiredService<ISprinklerRepository>();

                                await repository.UpdateAsync(sprinkler);

                            }
                            await _hubContext.Clients.All.SendAsync(device.Connection + "/power", false);

                        }
                        Console.WriteLine($"Who did action: {didAction}");
                        Console.WriteLine($"Action: {action}");
                        Console.WriteLine(device.Connection);
                        await _hubContext.Clients.All.SendAsync(device.Connection + "/action", didAction, action);
                        await SendSprinklerActionInfluxDataAsync(sprinkler, didAction, action);
                    }
                    else
                    {
                        Console.WriteLine("Invalid payload format");
                    }
                }
            };



            var scheduleClearClient = await _mqttClientService.SubscribeAsync(device.Connection + "/clearSchedule");

            actionClient.ApplicationMessageReceivedAsync += async e =>
            {
                string receivedTopic = e.ApplicationMessage.Topic;
                if (receivedTopic == device.Connection + "/clearSchedule")
                {
                    string payload = Encoding.UTF8.GetString(e.ApplicationMessage.Payload);
                    if (Guid.TryParse(payload, out Guid scheduleId))
                    {
                        Console.WriteLine("REMOVING SCHEDULE");
                        using (var scope = _scopeFactory.CreateScope())
                        {
                            var serviceProvider = scope.ServiceProvider;

                            var repository = serviceProvider.GetRequiredService<ISprinklerRepository>();

                            await repository.RemoveScheduleAsync(sprinkler.Id, scheduleId);
                        }
                        await _hubContext.Clients.All.SendAsync(device.Connection + "/schedule", await _sprinklerRepository.GetSprinklerSchedulesAsync(sprinkler.Id));
                    }
                }
            };
            return sprinkler;

        }

        public async Task TurnOn(Guid sprinklerId, string performedByUser)
        {
            var sprinkler = await _sprinklerRepository.GetByIdAsync(sprinklerId);
            sprinkler.Power = true;
            await _sprinklerRepository.UpdateAsync(sprinkler);
            await _hubContext.Clients.All.SendAsync(sprinkler.Connection + "/power", true);
            await _mqttClientService.PublishMessageAsync(sprinkler.Connection + "/turnOn", $"{performedByUser}");
        }

        public async Task TurnOff(Guid sprinklerId, string performedByUser)
        {
            var sprinkler = await _sprinklerRepository.GetByIdAsync(sprinklerId);
            sprinkler.Power = false;
            await _sprinklerRepository.UpdateAsync(sprinkler);
            await _hubContext.Clients.All.SendAsync(sprinkler.Connection + "/power", false);
            await _mqttClientService.PublishMessageAsync(sprinkler.Connection + "/turnOff", $"{performedByUser}");
        }

        public async Task<SprinklerSchedule> AddSchedule(Guid sprinklerId, SprinklerSchedule schedule)
        {
            var sprinkledId = Guid.NewGuid();
            var sprinkler = await _sprinklerRepository.GetByIdAsync(sprinklerId);
            schedule.Id = sprinkledId;
            await _sprinklerRepository.AddScheduleAsync(sprinkler.Id,schedule);
            string schedulesString = string.Join(",", (await _sprinklerRepository.GetSprinklerSchedulesAsync(sprinkler.Id)).Select(s => $"{s.Id}:-:{s.StartTime}:-:{s.DurationMinutes}"));
            await _mqttClientService.PublishMessageAsync(sprinkler.Connection + "/setSchedules", $"{schedulesString}");
            return schedule;
        }

        public async Task RemoveSchedule(Guid sprinklerId, Guid scheduleId)
        {
            var sprinkler = await _sprinklerRepository.GetByIdAsync(sprinklerId);
            var scheduleToRemove = await _sprinklerRepository.GetScheduleByIdAsync(scheduleId);

            if (scheduleToRemove != null)
            {
                await _sprinklerRepository.RemoveScheduleAsync(sprinklerId, scheduleId);
                string schedulesString = string.Join(",", (await _sprinklerRepository.GetSprinklerSchedulesAsync(sprinkler.Id)).Select(s => $"{s.Id}:-:{s.StartTime}:-:{s.DurationMinutes}"));
                await _mqttClientService.PublishMessageAsync(sprinkler.Connection + "/setSchedules", $"{schedulesString}");
                await _sprinklerRepository.UpdateAsync(sprinkler);
            }
        }

        private async Task SendSprinklerActionInfluxDataAsync(Sprinkler sprinkler, string userName, string action)
        {
            var point = PointData
                          .Measurement("Sprinkler actions")
                          .Tag("Id", sprinkler.Id.ToString())
                          .Field("action", action)
                          .Field("user", userName)
                          .Timestamp(DateTime.UtcNow, WritePrecision.Ns);

            await _influxClientService.WriteDataAsync(point);
        }


        public async Task<List<FluxTable>> GetInfluxDataAsync(string id, string h)
        {
            string query = $"from(bucket: \"bucket\")" +
                               $"|> range(start: -{h})" +
                               $"|> filter(fn: (r) => r._measurement == \"{"Sprinkler actions"}\" and r.Id == \"{id}\")" +
                               $"|> sort(columns: [\"_time\"], desc: false)" +
                               $"|> pivot(rowKey: [\"_time\"], columnKey: [\"_field\"], valueColumn: \"_value\")";
            var result = await _influxClientService.GetInfluxData(query);


            return result;
        }
        public async Task<List<FluxTable>> GetInfluxDataDateRangeAsync(string id, DateTime startDate, DateTime endDate)
        {
            string start = startDate.ToString("yyyy-MM-ddTHH:mm:ssZ");
            string end = endDate.ToString("yyyy-MM-ddTHH:mm:ssZ");

            string query = $"from(bucket: \"bucket\")" +
                           $"|> range(start: {start}, stop: {end})" +
                           $"|> filter(fn: (r) => r._measurement == \"{"Sprinkler actions"}\" and r.Id == \"{id}\")" +
                           $"|> sort(columns: [\"_time\"], desc: false)" +
                           $"|> pivot(rowKey: [\"_time\"], columnKey: [\"_field\"], valueColumn: \"_value\")";

            var result = await _influxClientService.GetInfluxData(query);

            return result;
        }

        public async Task<List<SprinklerSchedule>> GetSprinklerSchedules(Guid sprinklerId)
        {
            return await _sprinklerRepository.GetSprinklerSchedulesAsync(sprinklerId);
        }
    }

}
