using AutoMapper;
using Ecommerce.API.Data;
using Ecommerce.API.Models.Users;

namespace Ecommerce.API.Helper
{
    public class MapperConfig:Profile
    {
        public MapperConfig()
        {
            CreateMap<User, CreateUserModelDto>().ReverseMap();
            CreateMap<User,GetUserDto>().ReverseMap();
        }
    }
}
