using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHome.Application.HostedServices
{
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using SmartHome.Domain.Models;
    using SmartHome.Domain.Models.SmartDevices;
    using SmartHome.Domain.Repositories;
    using SmartHome.Domain.Services;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public class SimulationService : IHostedService, IDisposable
    {
        private readonly IServiceProvider _serviceProvider;
        private Timer _timer;

        public SimulationService(
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromMinutes(5));

            return Task.CompletedTask;
        }

        private void DoWork(object state)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var deviceRepository = scope.ServiceProvider.GetRequiredService<ISmartDeviceRepository>();
                var mqttClientService = scope.ServiceProvider.GetRequiredService<IMqttClientService>();
                var propertiesService = scope.ServiceProvider.GetRequiredService<IPropertyService>();
                var devicesService = scope.ServiceProvider.GetRequiredService<ISmartDeviceService>();
                var smartDeviceServiceFactory = scope.ServiceProvider.GetRequiredService<ISmartDeviceServiceFactory>();

                Pagination pagination = new Pagination
                        {
                            PageNumber = 1,
                            PageSize = int.MaxValue
                        };

                var properties = propertiesService.GetPropertiesByStatus(Domain.Models.PropertyStatus.Approved, pagination).Result.Items;

                foreach (var property in properties)
                {
                    mqttClientService.PublishMessageAsync("property/create", property.Id.ToString()).Wait();
                }

                Thread.Sleep(1000);
                foreach (var property in properties)
                {
                    var devices = devicesService.GetAllFromProperty(pagination, property.Id).Result.Items;
                    foreach (var device in devices)
                    {
                        Console.WriteLine(device.Type);
                        mqttClientService.PublishMessageAsync("property/" + property.Id.ToString() + "/create", device.Id.ToString() + "," + device.Type).Wait();
                        var deviceCreationSubscription = mqttClientService.SubscribeAsync("property/" + property.Id.ToString() + "/device/" + device.Id.ToString() + "/created").Result;
                        ISmartDeviceActionsService smartDeviceActionService = smartDeviceServiceFactory.GetServiceAsync(device.Id).Result;
                        deviceCreationSubscription.ApplicationMessageReceivedAsync += e =>
                        {

                            string receivedTopic = e.ApplicationMessage.Topic;
                            if (receivedTopic == ("property/" + property.Id.ToString() + "/device/" + device.Id.ToString() + "/created"))
                            {
                                smartDeviceActionService.Connect(device.Id).Wait();
                            }
                            return Task.CompletedTask;
                        };
                    }
                }
         
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }

}
