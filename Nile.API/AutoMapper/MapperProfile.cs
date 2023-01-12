using AutoMapper;
using Nile.API.DtoModels;
using Nile.Domain.EntityModel;

namespace Nile.API.AutoMapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            #region User
            CreateMap<User, UserRegisterDto>();
            CreateMap<UserRegisterDto, User>();
            CreateMap<User, LoggedUserDto>();
            CreateMap<LoggedUserDto, User>();
            #endregion
        }
    }
}
