using MQTTnet.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Domain.Services
{
    public interface IMqttClientService
    {
        Task ConnectAsync();
        Task<MqttClientPublishResult> PublishMessageAsync(string topic, string payload);
        Task<IMqttClient> SubscribeAsync(string topic);
        Task UnubscribeAsync(string topic);
        Task<IMqttClient> GetClient();
        Task<MqttClientPublishResult> PublishMessageAsyncNoRetain(string topic, string payload);
    }
}
