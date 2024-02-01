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


        public async Task<IMqttClient> ConnectAsync()
        {
            var factory = new MqttFactory();

            IMqttClient _mqttClient = factory.CreateMqttClient();
            var mqttOptions = new MqttClientOptionsBuilder()
                .WithClientId(Guid.NewGuid().ToString())
                .WithTcpServer("localhost", 8883)
                .Build();
            await _mqttClient.ConnectAsync(mqttOptions);
            return _mqttClient;
        }

      

        public async Task<MqttClientPublishResult> PublishMessageAsync(string topic, string payload)
        {

            IMqttClient client = await this.ConnectAsync();
            var message = new MqttApplicationMessageBuilder()
                .WithTopic(topic)
                .WithPayload(payload)
                .WithRetainFlag(true)
                .Build();
            MqttClientPublishResult res = await client.PublishAsync(message);
            await client.DisconnectAsync();
            return res;
        }
        public async Task<MqttClientPublishResult> PublishMessageAsyncNoRetain(string topic, string payload)
        {


            IMqttClient client = await this.ConnectAsync();
            var message = new MqttApplicationMessageBuilder()
                .WithTopic(topic)
                .WithPayload(payload)
                .WithRetainFlag(false)
                .Build();
            MqttClientPublishResult res = await client.PublishAsync(message);
            await client.DisconnectAsync();
            return res;
        }

        public async Task<IMqttClient> SubscribeAsync(string topic)
        {

            IMqttClient client = await this.ConnectAsync();

            await client.SubscribeAsync(topic);

            return client;
        }
        public async Task UnubscribeAsync(string topic)
        {
            IMqttClient client = await this.ConnectAsync();


            await client.UnsubscribeAsync(topic);
           
        }


    }
}
