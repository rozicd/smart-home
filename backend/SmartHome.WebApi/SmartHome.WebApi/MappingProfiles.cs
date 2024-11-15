using AutoMapper;
using SmartHome.Data.Entities;
using SmartHome.Data.Entities.SmartDevices;
using SmartHome.DataTransferObjects.Requests;
using SmartHome.DataTransferObjects.Responses;
using SmartHome.Domain.Models;
using SmartHome.Domain.Models.SmartDevices;
using SmartHome.Domain.Services;

public class MappingProfiles : Profile
{

    public MappingProfiles()
    {
        CreateMap<User, UserEntity>();
        CreateMap<UserEntity, User>();
        CreateMap<SmartDevice, SmartDeviceEntity>();
        CreateMap<SmartDeviceEntity, SmartDevice>();
        

        CreateMap<EnvironmentalConditionsSensor, EnvironmentalConditionsSensorEntity>()
            .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.GetType().Name));
        CreateMap<AirConditioner, AirConditionerEntity>()
            .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.GetType().Name));
        CreateMap<AirConditionerEntity, AirConditioner>();
        CreateMap<ACScheduledMode, ACScheduledModeEntity>();
        CreateMap<ACScheduledModeEntity, ACScheduledMode>();
        CreateMap<CreateACScheduledModeRequestDTO, ACScheduledMode>();
        CreateMap<ACScheduledMode, ACScheduledModeResponseDTO>();

        CreateMap<WashingMachine, WashingMachineEntity>()
            .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.GetType().Name));
        CreateMap<WashingMachineEntity, WashingMachine>();
        CreateMap<LampEntity, Lamp>();
        CreateMap<Lamp, LampEntity>()
            .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.GetType().Name));
        CreateMap<CarGateEntity, CarGate>();
        CreateMap<CarGate, CarGateEntity>()
            .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.GetType().Name));
        CreateMap<CarChargerEntity, CarCharger>();
        CreateMap<CarCharger, CarChargerEntity>()
            .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.GetType().Name));
        CreateMap<SprinklerEntity, Sprinkler>();
        CreateMap<Sprinkler, SprinklerEntity>()
            .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.GetType().Name));
        CreateMap<HomeBatteryEntity, HomeBattery>();
        CreateMap<HomeBattery, HomeBatteryEntity>()
            .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.GetType().Name));

        CreateMap<SolarPanelSystemEntity, SolarPanelSystem>();
        CreateMap<SolarPanelSystem, SolarPanelSystemEntity>()
                    .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.GetType().Name));

        CreateMap<WashingMachineModeEntity, WashingMachineMode>();
        CreateMap<WashingMachineMode, WashingMachineModeEntity>();
        CreateMap<WashingMachineMode, WashingMachineModeDTO>();
        CreateMap<WashingMachineModeDTO, WashingMachineMode>();
        CreateMap<WashingMachineResponseDTO, WashingMachine>();
        CreateMap<WashingMachine, WashingMachineResponseDTO>();
        CreateMap<WMScheduledMode, WMScheduledModeEntity>();
        CreateMap<WMScheduledModeEntity, WMScheduledMode>();
        CreateMap<CreateWMScheduledModeRequestDTO, WMScheduledMode>();
        CreateMap<WMScheduledMode, CreateWMScheduledModeRequestDTO>();
        CreateMap<WMScheduledMode, WMScheduledModeResponseDTO>();
        CreateMap<WMScheduledModeResponseDTO, WMScheduledMode>();
        CreateMap<SprinklerSchedule, SprinklerScheduleEntity>();
        CreateMap<SprinklerScheduleEntity, SprinklerSchedule>();
        CreateMap<CountriesAndCities, CountriesAndCitiesDTO>();
        CreateMap<CountriesAndCitiesDTO, CountriesAndCities>();
        CreateMap<EnvironmentalConditionsSensorEntity, EnvironmentalConditionsSensor>();
        CreateMap<Property, PropertyEntity>();
        CreateMap<PropertyEntity, Property>();
        CreateMap<City, CityEntity>();
        CreateMap<CityEntity, City>();
        CreateMap<Country, CountryEntity>();
        CreateMap<CountryEntity, Country>();
        CreateMap<CreateUserRequestDTO, User>();
        CreateMap<User, UserResponseDTO>();
        CreateMap<UserResponseDTO, User>();
        CreateMap<UpdateUserRequestDTO, User>();

        CreateMap<Country, CountryResponseDTO>();
        CreateMap<CarCharger, CarChargerResponseDTO>();




        CreateMap<WashingMachineModeDTO, WashingMachineMode>();
        CreateMap<CreateWashingMachineDTO, WashingMachine>();
        CreateMap<CreateCarGateDTO, CarGate>();
        CreateMap<CreateSprinklerDTO, Sprinkler>();
        CreateMap<CreateSolarPanelSystemDTO, SolarPanelSystem>();
        CreateMap<CreateHomeBatteryDTO, HomeBattery>();

        CreateMap<CreateCarChargerDTO, CarCharger>();



        CreateMap<CreateLampDTO, Lamp>();


        CreateMap<Lamp, LampResponseDTO>();

        CreateMap<EnvironmentalConditionsSensor, EnvironmentalContitionsSensorResponseDTO>();
        CreateMap<AirConditioner, AirConditionerResponseDTO>();

        CreateMap<CarGate, CarGateResponseDTO>()
                   .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.State.ToString()))
                   .ForMember(dest => dest.Mode, opt => opt.MapFrom(src => src.Mode.ToString()));
        CreateMap<SolarPanelSystem, SolarPanelSystemResponseDTO>();
        CreateMap<HomeBattery, HomeBatteryResponseDTO>();

        CreateMap<SprinklerSchedule, SprinklerScheduleResponseDTO>();
        CreateMap<Sprinkler, SprinklerResponseDTO>();

        CreateMap<CreateESCDTO, EnvironmentalConditionsSensor>();
        CreateMap<SprinklerScheduleDTO, SprinklerSchedule>();
        CreateMap<CreateAirConditionerDTO, AirConditioner>();

        CreateMap<PaginationReturnObject<Property>, PropertyResponseDTO>();
        CreateMap<RegisterPropertyRequestDTO, Property>();
        CreateMap<Property, PropertyResponseDTO>().ForMember(dest => dest.CityName, opt => opt.MapFrom(src => src.City.Name)).ForMember(dest => dest.CountryName, opt => opt.MapFrom(src => src.City.Country.Name));
        CreateMap<RegisterPropertyRequestDTO, Property>();
        CreateMap<SmartDevice, SmartDeviceResponseDTO>()
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.Name))
            .ForMember(dest => dest.PowerSupply, opt => opt.MapFrom(src => src.PowerSupply.ToString()))
            .ForMember(dest => dest.DeviceType, opt => opt.MapFrom(src => src.DeviceType.ToString()))
            .ForMember(dest => dest.DeviceStatus, opt => opt.MapFrom(src => src.DeviceStatus.ToString()));
        CreateMap<ActivationToken, ActivationTokenEntity>();
        CreateMap<ActivationTokenEntity, ActivationToken>();
        CreateMap<ActivationTokenRequestDTO, ActivationToken>()
           .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => Guid.Parse(src.UserId)))
           .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
           .ForMember(dest => dest.expires, opt => opt.MapFrom(src => (DateTime?)null));
        CreateMap<ActivationToken, ActivationTokenRequestDTO>();
        CreateMap<City, CityResponseDTO>().ForMember(dest => dest.CountryName, opt=> opt.MapFrom(src=>src.Country.Name)).ForMember(dest => dest.CountryId, opt => opt.MapFrom(src => src.Country.Id));


    }
}