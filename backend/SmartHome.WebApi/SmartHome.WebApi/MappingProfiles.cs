using AutoMapper;
using SmartHome.Data.Entities;
using SmartHome.DataTransferObjects.Requests;
using SmartHome.DataTransferObjects.Responses;
using SmartHome.Domain.Models;
using SmartHome.Domain.Services;

public class MappingProfiles : Profile
{

    public MappingProfiles()
    {
        CreateMap<User, UserEntity>();
        CreateMap<UserEntity, User>();
        CreateMap<Property, PropertyEntity>();
        CreateMap<PropertyEntity, Property>();
        CreateMap<City, CityEntity>();
        CreateMap<CityEntity, City>();
        CreateMap<Country, CountryEntity>();
        CreateMap<CountryEntity, Country>();
        CreateMap<CreateUserRequestDTO, User>();
        CreateMap<User, UserResponseDTO>();
        CreateMap<UpdateUserRequestDTO, User>();

        CreateMap<RegisterPropertyRequestDTO, Property>();
        CreateMap<Property, PropertyResponseDTO>().ForMember(dest => dest.CityName, opt => opt.MapFrom(src => src.City.Name)).ForMember(dest => dest.CountryName, opt => opt.MapFrom(src => src.City.Country.Name));

        CreateMap<ActivationToken, ActivationTokenEntity>();
        CreateMap<ActivationTokenEntity, ActivationToken>();
        CreateMap<ActivationTokenRequestDTO, ActivationToken>()
           .ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
           .ForMember(dest => dest.expires, opt => opt.MapFrom(src => (DateTime?)null));
        CreateMap<ActivationToken, ActivationTokenRequestDTO>();


    }
}