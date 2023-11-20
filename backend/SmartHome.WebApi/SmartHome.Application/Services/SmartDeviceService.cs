using SmartHome.Domain.Models;
using SmartHome.Domain.Models.SmartDevices;
using SmartHome.Domain.Repositories;
using SmartHome.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Application.Services
{
    public class SmartDeviceService : ISmartDeviceService
    {
        private readonly ISmartDeviceRepository _smartDeviceRepository;
        private readonly IMqttClientService _mqttClientService;
        private readonly Dictionary<string, Timer> topicTimers = new Dictionary<string, Timer>();


        public SmartDeviceService(ISmartDeviceRepository smartDeviceRepository, IMqttClientService mqttClientService)
        {
            _smartDeviceRepository = smartDeviceRepository;
            _mqttClientService = mqttClientService;


        }
        public async Task Connect(Guid id, string address)
        {
            await _smartDeviceRepository.Connect(id, address);
        }

        public Task<PaginationReturnObject<SmartDevice>> GetAll(Pagination page)
        {
            return _smartDeviceRepository.GetAll(page);
        }

        public async Task TurnOff(Guid id)
        {
            SmartDevice smartDevice = await _smartDeviceRepository.TurnOff(id);
            if (smartDevice == null) return;
            await _mqttClientService.ConnectAsync();
            await _mqttClientService.PublishMessageAsync(smartDevice.Connection + "/recive", "PowerOff");
            await _mqttClientService.UnubscribeAsync(smartDevice.Connection + "/status");
            return;
        }

        public async Task TurnOn(Guid id)
        {
            SmartDevice smartDevice = await _smartDeviceRepository.TurnOn(id);
            if (smartDevice == null) return;
            await _mqttClientService.ConnectAsync();
            await _mqttClientService.PublishMessageAsync(smartDevice.Connection+"/recive", "PowerOn");
            var client = await _mqttClientService.SubscribeAsync(smartDevice.Connection + "/status");
            TimeSpan timerInterval = TimeSpan.FromSeconds(15);

            if (topicTimers.ContainsKey(smartDevice.Connection + "/status"))
            {
                topicTimers[smartDevice.Connection + "/status"].Change(timerInterval,timerInterval);
            }
            else
            {
                var timer = new Timer(_=>CheckForNoMessagesAsync(id, smartDevice.Connection + "/status"), null, timerInterval, timerInterval);
                topicTimers[smartDevice.Connection + "/status"] = timer;
            }

            client.ApplicationMessageReceivedAsync += e =>
            {
                ResetTimer(smartDevice.Connection + "/status");

                Console.WriteLine($"Received message on topic {e.ApplicationMessage.Topic}: {Encoding.UTF8.GetString(e.ApplicationMessage.PayloadSegment)}");
                return Task.CompletedTask;
            };
            return;



        }
        private async Task CheckForNoMessagesAsync(Guid id,string topic)
        {
           

            
            Console.WriteLine($"No messages received for {id}. Device not responding.");
            _mqttClientService.UnubscribeAsync(topic);
            await _smartDeviceRepository.ForceTurnOff(id);
            topicTimers[topic].Dispose();
            topicTimers.Remove(topic);

        }
        private void ResetTimer(string topic)
        {
            topicTimers[topic].Change(TimeSpan.FromSeconds(15), TimeSpan.FromSeconds(15));
        }
    }
}
