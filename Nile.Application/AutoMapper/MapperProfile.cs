using AutoMapper;
using Nile.Application.Command.UserCommand;
using Nile.Application.DtoModels;
using Nile.Domain.EntityModel;

namespace Nile.Application.AutoMapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            #region User
            CreateMap<CreateUserCommand, User>();
            CreateMap<User, CreateUserCommand>();
            CreateMap<User, UserRegisterDto>();
            CreateMap<UserRegisterDto, User>();
            CreateMap<User, UserBasicDto>();
            CreateMap<UserBasicDto, User>();
            #endregion
        }
    }
}
