using SmartHome.Domain.Models;
using SmartHome.Domain.Repositories;
using SmartHome.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Application.Services
{
    public class PropertyService : IPropertyService
    {
        private readonly IPropertyRepository _propertyRepository;
        private readonly IMqttClientService _mqttClientService;

        public PropertyService(IPropertyRepository propertyRepository, IMqttClientService mqttClientService)
        {
            _propertyRepository = propertyRepository;
            _mqttClientService = mqttClientService;
        }

        public async Task AddProperty(Property property)
        {
            await _propertyRepository.Add(property);
        }

        public async Task<PaginationReturnObject<Property>> GetPropertiesByUserId(Guid userId, Pagination pagination)
        {
            return await _propertyRepository.GetPropertiesByUserId(userId, pagination);
        }

        public async Task<PaginationReturnObject<Property>> GetPropertiesByStatus(PropertyStatus status, Pagination pagination)
        {
            return await _propertyRepository.GetPropertiesByStatus(status,pagination);
        }

        public async Task<Property> GetPropertyById(Guid id)
        {
            return await _propertyRepository.GetById(id);
        }


        public async Task UpdateProperty(Property property)
        {
            await _propertyRepository.Update(property);
        }

        public async Task ListenOnCharge(Property property)
        {
            string topic = "property/" + property.Id + "/house_power";
            var client = await _mqttClientService.SubscribeAsync(topic);

            client.ApplicationMessageReceivedAsync += e =>
            {

                string receivedTopic = e.ApplicationMessage.Topic;
                if (receivedTopic == topic)
                {
                    string messageContent = Encoding.UTF8.GetString(e.ApplicationMessage.Payload);
                    Console.WriteLine($"Received message on topic: {e.ApplicationMessage.Topic}");
                    Console.WriteLine($"{messageContent}");
                }
                return Task.CompletedTask;
            };
        }
    }
}
