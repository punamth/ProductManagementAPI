using AutoMapper;
using ProductManagementAPI.Application.DTOs.Users;
using ProductManagementAPI.Domain.Entities;

namespace ProductManagementAPI.API.Mappers
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UpdateUserDto, User>();
        }
    }
}