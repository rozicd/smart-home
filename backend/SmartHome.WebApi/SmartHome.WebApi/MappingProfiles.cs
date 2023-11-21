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

        CreateMap<EnvironmentalConditionsSensor, EnvironmentalConditionsSensorEntity>();
        CreateMap<AirConditioner, AirConditionerEntity>();
        CreateMap<AirConditionerEntity, AirConditioner>();
        CreateMap<WashingMachine, WashingMachineEntity>();
        CreateMap<WashingMachineEntity, WashingMachine>();
        CreateMap<LampEntity, Lamp>();
        CreateMap<Lamp, LampEntity>();
        CreateMap<CarGateEntity, CarGate>();
        CreateMap<CarGate, CarGateEntity>();
        CreateMap<CarChargerEntity, CarCharger>();
        CreateMap<CarCharger, CarChargerEntity>();
        CreateMap<SprinklerEntity, Sprinkler>();
        CreateMap<Sprinkler, SprinklerEntity>();
        CreateMap<HomeBatteryEntity, HomeBattery>();
        CreateMap<HomeBattery, HomeBatteryEntity>();
        CreateMap<SolarPanelSystemEntity, SolarPanelSystem>();
        CreateMap<SolarPanelSystem, SolarPanelSystemEntity>();
        CreateMap<WashingMachineModeEntity, WashingMachineMode>();
        CreateMap<WashingMachineMode, WashingMachineModeEntity>();
        CreateMap<SolarPanelEntity, SolarPanel>();
        CreateMap<SolarPanel, SolarPanelEntity>();
        CreateMap<SprinkleMode, SprinkleModeEntity>();
        CreateMap<SprinkleModeEntity, SprinkleMode>();


        CreateMap<EnvironmentalConditionsSensorEntity, EnvironmentalConditionsSensor>();
        CreateMap<Property, PropertyEntity>();
        CreateMap<PropertyEntity, Property>();
        CreateMap<City, CityEntity>();
        CreateMap<CityEntity, City>();
        CreateMap<Country, CountryEntity>();
        CreateMap<CountryEntity, Country>();
        CreateMap<CreateUserRequestDTO, User>();
        CreateMap<User, UserResponseDTO>();
        CreateMap<UpdateUserRequestDTO, User>();

        CreateMap<WashingMachineModeDTO, WashingMachineMode>();
        CreateMap<CreateWashingMachineDTO, WashingMachine>();
        CreateMap<CreateCarGateDTO, CarGate>();
        CreateMap<CreateSprinklerDTO, Sprinkler>();
        CreateMap<CreateSolarPanelDTO, SolarPanel>();
        CreateMap<CreateSolarPanelSystemDTO, SolarPanelSystem>();
        CreateMap<CreateHomeBatteryDTO, HomeBattery>();

        CreateMap<CreateCarChargerDTO, CarCharger>();



        CreateMap<CreateLampDTO, Lamp>();




        CreateMap<CreateESCDTO, EnvironmentalConditionsSensor>();
        CreateMap<CreateAirConditionerDTO, AirConditioner>();

        CreateMap<PaginationReturnObject<Property>, PropertyResponseDTO>();
        CreateMap<RegisterPropertyRequestDTO, Property>();
        CreateMap<Property, PropertyResponseDTO>().ForMember(dest => dest.CityName, opt => opt.MapFrom(src => src.City.Name)).ForMember(dest => dest.CountryName, opt => opt.MapFrom(src => src.City.Country.Name));
        CreateMap<RegisterPropertyRequestDTO, Property>();
        CreateMap<SmartDevice, SmartDeviceResponseDTO>().ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.Name));
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