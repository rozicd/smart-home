using System;
using MQTTnet;
using MQTTnet.Client;

using MQTTnet.Server;
using SmartHome.Domain.Services;
using System.Threading.Tasks;
using System.Text;

namespace SmartHome.Application.Services
{
    public class MqttClientService : IMqttClientService
    {
        public IMqttClient _mqttClient;


        public MqttClientService() {
            this.ConnectAsync();
        }
        public async Task ConnectAsync()
        {
            var factory = new MqttFactory();

            _mqttClient = factory.CreateMqttClient();
            var mqttOptions = new MqttClientOptionsBuilder()
                .WithClientId(Guid.NewGuid().ToString())
                .WithTcpServer("localhost", 8883)
                .Build();
            await _mqttClient.ConnectAsync(mqttOptions);
        }

        public Task<IMqttClient> GetClient()
        {
            return (Task<IMqttClient>)_mqttClient;
        }

        public async Task<MqttClientPublishResult> PublishMessageAsync(string topic, string payload)
        {
            var message = new MqttApplicationMessageBuilder()
                .WithTopic(topic)
                .WithPayload(payload)
                .WithRetainFlag(true)
                .Build();

            return await _mqttClient.PublishAsync(message);
        }
        public async Task<MqttClientPublishResult> PublishMessageAsyncNoRetain(string topic, string payload)
        {
            var message = new MqttApplicationMessageBuilder()
                .WithTopic(topic)
                .WithPayload(payload)
                .WithRetainFlag(false)
                .Build();

            return await _mqttClient.PublishAsync(message);
        }

        public async Task<IMqttClient> SubscribeAsync(string topic)
        {
           
            await _mqttClient.SubscribeAsync(topic);

            return _mqttClient;
        }
        public async Task UnubscribeAsync(string topic)
        {

            await _mqttClient.UnsubscribeAsync(topic);
           
        }


    }
}
