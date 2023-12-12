using InfluxDB.Client.Api.Domain;
using InfluxDB.Client.Writes;
using Microsoft.Extensions.DependencyInjection;
using MQTTnet.Client;
using SmartHome.Domain.Models;
using SmartHome.Domain.Models.SmartDevices;
using SmartHome.Domain.Repositories;
using SmartHome.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Application.Services
{
    public class SmartDeviceService : ISmartDeviceService,ISmartDeviceActionsService
    {
        protected readonly ISmartDeviceRepository _smartDeviceRepository;
        protected readonly IMqttClientService _mqttClientService;
        protected readonly IInfluxClientService _influxClientService;
        protected readonly IServiceScopeFactory _scopeFactory;
        private static readonly Dictionary<string, Timer> topicTimers = new Dictionary<string, Timer>();



        public SmartDeviceService(ISmartDeviceRepository smartDeviceRepository, IMqttClientService mqttClientService, IInfluxClientService influxClientService, IServiceScopeFactory scopeFactory)
        {
            _smartDeviceRepository = smartDeviceRepository;
            _mqttClientService = mqttClientService;
            _influxClientService = influxClientService;
            _scopeFactory = scopeFactory;


        }


        public async Task<PaginationReturnObject<SmartDevice>> GetAll(Pagination page)
        {
            return await _smartDeviceRepository.GetAll(page);
        }

        public async Task<PaginationReturnObject<SmartDevice>> GetAllFromProperty(Pagination page, Guid propertyId)
        {
            return await _smartDeviceRepository.GetAllFromProperty(page, propertyId);
        }

        virtual public async Task Disconnect(Guid id)
        {
            SmartDevice smartDevice = await _smartDeviceRepository.TurnOff(id);

            if (smartDevice == null) return;

            Console.WriteLine($"Turning off {smartDevice.Id}");

            await _mqttClientService.PublishMessageAsync(smartDevice.Connection + "/recive", "PowerOff");

            return;
        }

        virtual public async Task<SmartDevice> Connect(Guid id)
        {
            SmartDevice smartDevice;
            using (var scope = _scopeFactory.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;

                var repository = serviceProvider.GetRequiredService<ISmartDeviceRepository>();

                smartDevice= await repository.TurnOn(id);
            }
            if (smartDevice == null) return null;

            Console.WriteLine($"Turning on {smartDevice.Id}");
            await _mqttClientService.PublishMessageAsync(smartDevice.Connection + "/recive", "PowerOn");
            var client = await _mqttClientService.SubscribeAsync(smartDevice.Connection + "/status");

            TimeSpan timerInterval = TimeSpan.FromSeconds(15);
            var timer = new Timer(_ => CheckForNoMessagesAsync(smartDevice, smartDevice.Connection + "/status"), null, timerInterval, timerInterval);
            topicTimers[smartDevice.Connection + "/status"] = timer;

            client.ApplicationMessageReceivedAsync += e =>
            {
                string receivedTopic = e.ApplicationMessage.Topic;
                if (receivedTopic == smartDevice.Connection + "/status")
                {
                    ResetTimer(smartDevice.Connection + "/status");
                    string messageContent = Encoding.UTF8.GetString(e.ApplicationMessage.Payload);
                    Console.WriteLine($"Received message on topic: {e.ApplicationMessage.Topic}");
                    Console.WriteLine($"Message content: {messageContent}");
                    SendInfluxDataAsync(smartDevice, 1);
                }
                return Task.CompletedTask;
            };
            return smartDevice;
        }
        private async Task CheckForNoMessagesAsync(SmartDevice smartDevice,string topic)
        {
           
            Console.WriteLine($"No messages received for {smartDevice.Id}. Device not responding.");
            try
            {
                using (var scope = _scopeFactory.CreateScope())
                {
                    var serviceProvider = scope.ServiceProvider;

                    var repository = serviceProvider.GetRequiredService<ISmartDeviceRepository>();

                    await repository.TurnOff(smartDevice.Id);
                }
            }

            catch(Exception ex) { Console.WriteLine(ex.Message); }

            if (topicTimers.ContainsKey(topic))
            {
                topicTimers[topic].Dispose();
                topicTimers.Remove(topic);
            }



        }
        private void ResetTimer(string topic)
        {
            topicTimers[topic].Change(TimeSpan.FromSeconds(15), TimeSpan.FromSeconds(15));
        }


        private async Task SendInfluxDataAsync(SmartDevice smartDevice, int status)
        {
            var point = PointData
                          .Measurement(smartDevice.Name)
                          .Field("status", status)
                          .Timestamp(DateTime.UtcNow, WritePrecision.Ns);
            await _influxClientService.WriteDataAsync(point);
        }
    }
}
