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

        public SimulationService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            // Call DoWork directly when the service starts
            DoWork(null);

            // Return a completed task
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

                    mqttClientService.ConnectAsync().Wait();
                    mqttClientService.PublishMessageAsync("property/create", property.Id.ToString()).Wait();
                    propertiesService.ListenOnCharge(property);
                    var devices = devicesService.GetAllFromProperty(pagination, property.Id).Result.Items;
                    Thread.Sleep(2000);

                    foreach (var device in devices)
                    {
                        Console.WriteLine(device.Type);
                        Console.WriteLine(device.Id);
                        Console.WriteLine(device.Name);
                        Console.WriteLine(device.Connection);

                        mqttClientService.ConnectAsync().Wait();
                        mqttClientService.PublishMessageAsync("property/" + property.Id.ToString() + "/create", device.Id.ToString() + "," + device.Type).Wait();

                        ISmartDeviceActionsService smartDeviceActionService = smartDeviceServiceFactory.GetServiceAsync(device.Id).Result;
                        smartDeviceActionService.Connect(device.Id).Wait();
                        Thread.Sleep(100);
                    }


                }


            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            // No need to stop anything since there is no timer
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            // No need to dispose anything since there is no timer
        }
    }


}
