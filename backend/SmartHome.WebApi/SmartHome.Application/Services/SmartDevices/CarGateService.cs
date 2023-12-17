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
using static SmartHome.Domain.Models.SmartDevices.CarGate;
using SmartHome.Domain.Exceptions;
using Microsoft.AspNetCore.SignalR;
using InfluxDB.Client.Api.Domain;
using InfluxDB.Client.Writes;
using SmartHome.Application.Hubs;
using InfluxDB.Client.Core.Flux.Domain;

namespace SmartHome.Application.Services.SmartDevices
{
    public class CarGateService : SmartDeviceService,ICarGateService
    {
        private readonly ICarGateRepository _carGateRepository;
        private readonly IHubContext<CarGateHub> _hubContext;

        public CarGateService(
            ICarGateRepository carGateRepository,
            ISmartDeviceRepository smartDeviceRepository,
            IMqttClientService mqttClientService,
            IHubContext<CarGateHub> hubContext,
            IInfluxClientService influxClientService,
            IServiceScopeFactory scopeFactory)
            : base(smartDeviceRepository, mqttClientService, influxClientService, scopeFactory)
        {
            _carGateRepository = carGateRepository;
            _hubContext = hubContext;
        }

        public async Task Add(CarGate carGate)
        {
            carGate.Id = Guid.NewGuid();
            carGate.Connection = "property/" + carGate.PropertyId + "/device/" + carGate.Id;
            await _carGateRepository.Add(carGate);
        }

        public async Task<CarGate> GetById(Guid lampId)
        {
            return await _carGateRepository.GetById(lampId);
        }

        public async Task OpenGate(Guid carGateId, string performedByUser)
        {
            var carGate = await _carGateRepository.GetById(carGateId);
            if (carGate.State != CarGateState.CLOSED)
            {
                throw new RequestValuesException("Car gate is not in the CLOSED state");
            }

            await _mqttClientService.PublishMessageAsync(carGate.Connection + "/openGate", $"{performedByUser}");
        }

        public async Task CloseGate(Guid carGateId, string performedByUser)
        {
            var carGate = await _carGateRepository.GetById(carGateId);
            if (carGate.State != CarGateState.OPEN)
            {
                throw new RequestValuesException("Car gate is not in the OPEN state");
            }

            await _mqttClientService.PublishMessageAsync(carGate.Connection + "/closeGate", $"{performedByUser}");
        }

        public async Task ChangeMode(Guid carGateId, CarGateMode newMode)
        {
            var carGate = await _carGateRepository.GetById(carGateId);

            await _mqttClientService.PublishMessageAsync(carGate.Connection + "/setMode", newMode.ToString());

            carGate.Mode = newMode;
            await _carGateRepository.Update(carGate);
        }

        override public async Task<SmartDevice> Connect(Guid id)
        {
            SmartDevice device = await base.Connect(id);
            Console.WriteLine("U CarGate");
            CarGate carGate;
            using (var scope = _scopeFactory.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;

                var repository = serviceProvider.GetRequiredService<ICarGateRepository>();

                carGate = await repository.GetById(device.Id);
            }
            await _mqttClientService.PublishMessageAsync(device.Connection + "/info", $"{carGate.Mode},{carGate.State},{string.Join(",", carGate.AllowedLicensePlates)}");
            var client = await _mqttClientService.SubscribeAsync(device.Connection + "/gateStatus");

            var actionClient = await _mqttClientService.SubscribeAsync(device.Connection + "/action");

            client.ApplicationMessageReceivedAsync += async e =>
            {
                string receivedTopic = e.ApplicationMessage.Topic;
                if (receivedTopic == device.Connection + "/gateStatus")
                {
                    Console.Write("U VRATIMA SAM");
                    Console.Write(Encoding.UTF8.GetString(e.ApplicationMessage.Payload));
                    string payload = Encoding.UTF8.GetString(e.ApplicationMessage.Payload);

                    CarGateState carGateState;
                    if(Enum.TryParse<CarGateState>(payload, out carGateState))
                    carGate.State = carGateState;
                    using (var scope = _scopeFactory.CreateScope())
                    {
                        var serviceProvider = scope.ServiceProvider;

                        var repository = serviceProvider.GetRequiredService<ICarGateRepository>();

                        await repository.Update(carGate);
                    }
                    await _hubContext.Clients.All.SendAsync(device.Connection, payload);


                }
            };

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
                        if(action == "1")
                        {
                            action = "Vehicle entered";
                        }
                        else if (action == "2")
                        {
                            action = "Vehicle exited";
                        }
                        else if (action == "3")
                        {
                            action = "Opened gate";
                        }
                        else if (action == "4")
                        {
                            action = "Closed gate";
                        }
                        Console.WriteLine($"Who did action: {didAction}");
                        Console.WriteLine($"Action: {action}");
                        Console.WriteLine(device.Connection);
                        await SendGateActionInfluxDataAsync(carGate, didAction, action, carGate.Mode);
                    }
                    else
                    {
                        Console.WriteLine("Invalid payload format");
                    }
                }
            };
            return carGate;

        }

        private async Task SendGateActionInfluxDataAsync(CarGate carGate, string userName, string action, CarGateMode gateMode)
        {
            var point = PointData
                          .Measurement("Car actions")
                          .Tag("Id", carGate.Id.ToString())
                          .Field("action", action)
                          .Field("user", userName)
                          .Timestamp(DateTime.UtcNow, WritePrecision.Ns);

            await _influxClientService.WriteDataAsync(point);
        }

        public async Task AddLicensePlate(Guid carGateId, string licensePlate)
        {
            var carGate = await _carGateRepository.GetById(carGateId);


            carGate.AllowedLicensePlates.Add(licensePlate);
            await _mqttClientService.PublishMessageAsync(carGate.Connection + "/setAllowedVehicles", string.Join(",", carGate.AllowedLicensePlates));

            await _carGateRepository.Update(carGate);
        }

        public async Task RemoveLicensePlate(Guid carGateId, string licensePlate)
        {
            var carGate = await _carGateRepository.GetById(carGateId);

            carGate.AllowedLicensePlates.Remove(licensePlate);
            await _mqttClientService.PublishMessageAsync(carGate.Connection + "/setAllowedVehicles", string.Join(",", carGate.AllowedLicensePlates));
            await _carGateRepository.Update(carGate);
        }

        public async Task<List<FluxTable>> GetCarGateInfluxDataAsync(Guid carGateId, DateTime startDate, DateTime endDate)
        {
            var query = $"from(bucket:\"bucket\") |> range(start: {startDate:yyyy-MM-dd'T'HH:mm:ss.fff'Z'}, stop: {endDate:yyyy-MM-dd'T'HH:mm:ss.fff'Z'}) |> filter(fn: (r) => r[\"_measurement\"] == \"Car actions\") |> filter(fn: (r) => r[\"Id\"] == \"{carGateId}\") |> sort(columns: [\"_time\"], desc: false)  |> pivot(rowKey: [\"_time\"], columnKey: [\"_field\"], valueColumn: \"_value\")";

            var fluxTable = await _influxClientService.GetInfluxData(query);

            return fluxTable;
        }




    }

}
