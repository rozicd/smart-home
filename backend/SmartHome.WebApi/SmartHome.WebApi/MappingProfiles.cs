using AutoMapper;
using SmartHome.Application.Services;
using SmartHome.Data.Entities;
using SmartHome.DataTransferObjects.Requests;
using SmartHome.DataTransferObjects.Responses;
using SmartHome.Domain.Models;
using SmartHome.Domain.Services;

namespace SmartHome.WebApi
{
    public class MappingProfiles : Profile
    {
        private readonly ICityService _cityService;
        private readonly ICountryService _countryService;

        public MappingProfiles(ICityService cityService, ICountryService countryService) 
        {
            _cityService = cityService;
            _countryService = countryService;

            CreateMap<User, UserEntity>();
            CreateMap<UserEntity, User>();
            CreateMap<Property, PropertyEntity>();
            CreateMap<PropertyEntity, Property>();
            CreateMap<City, CityEntity>();
            CreateMap<CityEntity, City>();
            CreateMap<Country, CountryEntity>();
            CreateMap<CountryEntity, Country>();
            CreateMap<CreateUserRequestDTO, User>();
            CreateMap<User,UserResponseDTO>();
            CreateMap<UpdateUserRequestDTO, User>();

            CreateMap<RegisterPropertyRequestDTO, Property>()
                .ForMember(dest => dest.City, opt => opt.Ignore());

            CreateMap<Property, PropertyResponseDTO>()
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => new CityResponseDTO
                {
                    Name = _cityService.GetCityById(src.City.Id).Result.Name,
                    Country = new CountryResponseDTO
                    {
                        Name = _countryService.GetCountryById(_cityService.GetCityById(src.City.Id).Result.CountryId).Result.Name,
                    }
                }));
        }
    }
}
