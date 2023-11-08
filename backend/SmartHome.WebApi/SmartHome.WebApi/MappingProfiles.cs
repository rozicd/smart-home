using AutoMapper;
using SmartHome.Data.Entities;
using SmartHome.DataTransferObjects.Requests;
using SmartHome.DataTransferObjects.Responses;
using SmartHome.Domain.Models;

namespace SmartHome.WebApi
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles() 
        {
            CreateMap<User, UserEntity>();
            CreateMap<UserEntity, User>();
            CreateMap<CreateUserRequestDTO, User>();
            CreateMap<User,UserResponseDTO>();
            CreateMap<UpdateUserRequestDTO, User>();
        }
    }
}
