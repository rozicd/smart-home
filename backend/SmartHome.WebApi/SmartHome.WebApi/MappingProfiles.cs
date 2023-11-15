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
        CreateMap<Property, PropertyResponseDTO>();
        CreateMap<City, CityResponseDTO>();
        CreateMap<Country, CountryResponseDTO>();

    }
}