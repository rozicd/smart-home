using Microsoft.Extensions.DependencyInjection;
using SmartHome.Domain.Repositories;
using SmartHome.Domain.Services.SmartDevices;
using SmartHome.Domain.Services;
using SmartHome.Application.Services.SmartDevices;

public class SmartDeviceServiceFactory : ISmartDeviceServiceFactory
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ISmartDeviceRepository _smartDeviceRepository;

    public SmartDeviceServiceFactory(IServiceProvider serviceProvider, ISmartDeviceRepository smartDeviceRepository)
    {
        _serviceProvider = serviceProvider;
        _smartDeviceRepository = smartDeviceRepository;
    }

    public async Task<ISmartDeviceActionsService> GetServiceAsync(Guid deviceId)
    {
        string deviceType = await _smartDeviceRepository.GetDeviceType(deviceId);

        switch (deviceType)
        {
            case "AirConditioner":
                return _serviceProvider.GetRequiredService<IAirConditionerService>();

            case "CarCharger":
                return _serviceProvider.GetRequiredService<ICarChargerService>();

            case "CarGate":
                return _serviceProvider.GetRequiredService<ICarGateService>();

            case "EnviromentalConditionsSensor":
                return _serviceProvider.GetRequiredService<IEnvironmentalConditionsSensorService>();

            case "HomeBattery":
                return _serviceProvider.GetRequiredService<IHomeBatteryService>();

            case "Lamp":
                return _serviceProvider.GetRequiredService<ILampService>();

            case "SolarPanelSystem":
                return _serviceProvider.GetRequiredService<ISolarPanelSystemService>();

            case "Sprinkler":
                return _serviceProvider.GetRequiredService<ISprinklerService>();

            case "WashingMachine":
                return _serviceProvider.GetRequiredService<IWashingMachineService>();
            default:
                return _serviceProvider.GetRequiredService<ISmartDeviceActionsService>();
        }
    }

}

