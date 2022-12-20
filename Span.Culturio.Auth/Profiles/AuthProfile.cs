using AutoMapper;
using Span.Culturio.Auth.Data.Entities;
using Span.Culturio.Core.Models.Users;

namespace Span.Culturio.Auth.Profiles
{
    public class AuthProfile : Profile
    {
        public AuthProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<CreateUserDto, User>();
        }
    }
}