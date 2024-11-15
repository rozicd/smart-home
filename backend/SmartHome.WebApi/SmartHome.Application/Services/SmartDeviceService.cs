﻿using InfluxDB.Client.Api.Domain;
using InfluxDB.Client.Core.Flux.Domain;
using InfluxDB.Client.Writes;
using Microsoft.Extensions.DependencyInjection;
using MQTTnet.Client;
using NodaTime;
using SmartHome.Domain.Models;
using SmartHome.Domain.Models.SmartDevices;
using SmartHome.Domain.Repositories;
using SmartHome.Domain.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;
using User = SmartHome.Domain.Models.User;

namespace SmartHome.Application.Services
{
    public class SmartDeviceService : ISmartDeviceService, ISmartDeviceActionsService
    {
        protected readonly ISmartDeviceRepository _smartDeviceRepository;
        protected readonly IMqttClientService _mqttClientService;
        protected readonly IInfluxClientService _influxClientService;
        protected readonly IServiceScopeFactory _scopeFactory;


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

        public async Task<PaginationReturnObject<SmartDevice>> GetAllFromProperty(Pagination page, Guid propertyId, LoggedUser user)
        {
            var devices = await _smartDeviceRepository.GetAllFromProperty(page, propertyId);

            if (devices.Items.Count() != 0 && devices.Items.ElementAt(0).Property.UserId != user.UserId)
            {
                devices.Items = devices.Items.Where(device => device.SharedUsers.Any(user => user.Id == user.Id)).ToList();
                devices.TotalItems = devices.Items.Count();
            }
            return devices;
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

                smartDevice = await repository.TurnOn(id);
            }
            if (smartDevice == null) return null;

            var client = await _mqttClientService.SubscribeAsync(smartDevice.Connection + "/status");



            client.ApplicationMessageReceivedAsync += e =>
            {
                string receivedTopic = e.ApplicationMessage.Topic;
                if (receivedTopic == smartDevice.Connection + "/lastWill")
                {
                    using (var scope = _scopeFactory.CreateScope())
                    {
                        var serviceProvider = scope.ServiceProvider;

                        var repository = serviceProvider.GetRequiredService<ISmartDeviceRepository>();

                        repository.TurnOff(smartDevice.Id);
                    }
                }
                else if (receivedTopic == smartDevice.Connection + "/status")
                {
                    string messageContent = Encoding.UTF8.GetString(e.ApplicationMessage.Payload);

                    SendInfluxDataAsync(smartDevice, 1);
                }
                return Task.CompletedTask;
            };
            return smartDevice;
        }
        public async Task<float> GetDeviceLastValue(Guid id)
        {
           
            return 0;
        }

        public async Task<List<FluxTable>> GetInfluxDataAsync(string id, string h)
        {

            string aggregation;
            string units;
            string multipicator;
            string dorh;
            string query;
            if (!(h == "7d" || h == "30d"))
            {
                aggregation = "1h";
                units = "1m";
                multipicator = "60";
                dorh = "h";
                query = $"from(bucket: \"bucket\")" +
               $"|> range(start: -{h})" +
               $"|> filter(fn: (r) => r._measurement == \"Device status\" and r.Id == \"{id}\")" +
               $"|> window(every: {aggregation}, createEmpty: false)" +
               $"|> stateDuration(fn: (r) => r._value == 1, unit: {units})" +
               $"|> last()" +
               $"|>map(fn: (r) => (" + "{" + "time:r._time,duration: r.stateDuration+1,percentage: (r.stateDuration+1) * 100/" +
               multipicator + ",units:" + $"\"{dorh}\"" + "}" + "))";
            }
            else
            {
                aggregation = "1h";
                units = "1m";
                multipicator = "24";
                dorh = "d";
                query = $"from(bucket: \"bucket\")" +
                           $"|> range(start: -{h})" +
                           $"|> filter(fn: (r) => r._measurement == \"Device status\" and r.Id == \"{id}\")" +
                           $"|> window(every: {aggregation}, createEmpty: false)" +
                           $"|> stateDuration(fn: (r) => r._value == 1, unit: {units})" +
                           $"|> last()" +
                           "|> map(fn: (r) => ({_value : r.stateDuration+1, _time:r._time}))  |> aggregateWindow(every: 1d, fn: sum)|> filter(fn: (r) => exists r._value and exists r._time) " +
                           $"|>map(fn: (r) => (" + "{" + "time:r._time,duration: r._value/60,percentage: (r._value/60) * 100/" +
                           multipicator + ",units:" + $"\"{dorh}\"" + "}" + "))";
            }



            var result = await _influxClientService.GetInfluxData(query);   

            Console.WriteLine(result);
            return result;
        }
        public async Task<List<FluxTable>> GetInfluxDataDateRangeAsync(string id, DateTime startDate, DateTime endDate)
        {
            string start = startDate.ToString("yyyy-MM-ddTHH:mm:ssZ");
            string end = endDate.ToString("yyyy-MM-ddTHH:mm:ssZ");

            string aggregation;
            string units;
            string multipicator;
            string dorh;
            string query;

            if ((endDate - startDate).TotalDays <= 2)
            {
                aggregation = "1h";
                units = "1m";
                multipicator = "60";
                dorh = "h";
                query = $"from(bucket: \"bucket\")" +
                           $"|> range(start: {start}, stop: {end})" +
                        $"|> filter(fn: (r) => r._measurement == \"Device status\" and r.Id == \"{id}\")" +
                        $"|> window(every: {aggregation}, createEmpty: false)" +
                        $"|> stateDuration(fn: (r) => r._value == 1, unit: {units})" +
                        $"|> last()" +
                        $"|>map(fn: (r) => (" + "{" + "time:r._time,duration: r.stateDuration+1,percentage: (r.stateDuration+1) * 100/" +
                        multipicator + ",units:" + $"\"{dorh}\"" + "}" + "))";
            }
            else
            {
                aggregation = "1h";
                units = "1m";
                multipicator = "24";
                dorh = "d";
                query = $"from(bucket: \"bucket\")" +
                           $"|> range(start: {start}, stop: {end})" +
                           $"|> filter(fn: (r) => r._measurement == \"Device status\" and r.Id == \"{id}\")" +
                           $"|> window(every: {aggregation}, createEmpty: false)" +
                           $"|> stateDuration(fn: (r) => r._value == 1, unit: {units})" +
                           $"|> last()" +
                           " |> map(fn: (r) => ({_value : r.stateDuration+1, _time:r._time}))  |> aggregateWindow(every: 1d, fn: sum) |> filter(fn: (r) => exists r._value and exists r._time) " +
                           $"|>map(fn: (r) => (" + "{" + "time:r._time,duration: r._value/60,percentage: (r._value/60) * 100/" +
                           multipicator + ",units:" + $"\"{dorh}\"" + "}" + "))";
            }


            var result = await _influxClientService.GetInfluxData(query);

            return result;
        }

        private async Task SendInfluxDataAsync(SmartDevice smartDevice, int status)
        {
            var point = PointData
                          .Measurement("Device status")
                          .Tag("Id", smartDevice.Id.ToString())
                          .Field("status", status);
            await _influxClientService.WriteDataAsync(point);
        }

        public async Task<User> addUserPermission(Guid id, string email)
        {
            User user = await _smartDeviceRepository.addUserPermission(id, email);
       
            return user;
        }

        public async Task<User> RemoveUserPermission(Guid id, string email)
        {
            User user = await _smartDeviceRepository.removeUserPermission(id, email);
          
            return user;
        }

        public async Task<SmartDevice> GetDeviceById(Guid id)
        {
            return await _smartDeviceRepository.getById(id);
        }
        public async Task<List<SmartDevice>> GetAllFromPropertyNoPage(Guid propertyId)
        {
            return await _smartDeviceRepository.GetAllFromPropertyNoPage(propertyId);
        }
    }
}
