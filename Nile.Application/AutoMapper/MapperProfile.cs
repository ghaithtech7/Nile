using Nile.Application.UserApp.Commands;
using Nile.Application.UserApplication.Commands;
using Nile.Domain.EntityModel;
namespace Nile.Application.AutoMapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            #region User
            CreateMap<CreateUserCommand, Nile.Domain.EntityModel.User>();
            CreateMap<Nile.Domain.EntityModel.User, CreateUserCommand>();
            CreateMap<Nile.Domain.EntityModel.User, UserRegisterDto>();
            CreateMap<UserRegisterDto, Nile.Domain.EntityModel.User>();
            CreateMap<Nile.Domain.EntityModel.User, UserBasicDto>();
            CreateMap<UserBasicDto, Nile.Domain.EntityModel.User>();
            #endregion

            #region Role
            CreateMap<AddUserRoleCommand, UserRoleDto>();
            CreateMap<UserRoleDto, AddUserRoleCommand>();
            CreateMap<Role, UserRoleDto>();
            CreateMap<UserRoleDto, Role>();
            #endregion

            #region Cart
            CreateMap<CartOrder, CartOrderDto>();
            CreateMap<CartOrderDto, CartOrder>();
            #endregion

            #region Product
            CreateMap<CreateProductDto, Product>();
            CreateMap<Product, CreateProductDto>();
            #endregion

            #region Order
            CreateMap<AddOrderDto, Order>();
            CreateMap<Order, AddOrderDto>();
            #endregion
        }
    }
}
