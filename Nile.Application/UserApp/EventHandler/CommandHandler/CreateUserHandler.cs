using Nile.Application.Services.CartServices;
using Nile.Application.UserApplication.Commands;
using Nile.Application.UserServicves;
using Nile.Domain.EntityModel;

namespace Nile.Application.UserApplication.EventHandler.CommandHandler
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, UserBasicDto>
    {
        private readonly IUserServices _userServices;
        private readonly ICartServices _cartServices;
        private readonly IMapper _mapper;
        public CreateUserHandler(IUserServices userServices,
                                 ICartServices cartServices,
                                 IMapper mapper)
        {
            _userServices = userServices;
            _cartServices = cartServices;
            _mapper = mapper;
        }

        public async Task<UserBasicDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            if (!_userServices.CheckPasswordMatch(request.Password, request.ConfirmPassword))
            {
                return null;
            }
            User userRegister = new User();
            userRegister = _mapper.Map<User>(request);
            userRegister.PasswordHash = _userServices.PassowrdHash(request.Password);

            User userRegistered = await _userServices.RegisterUser(userRegister);
            if (userRegistered == null)
            {
                return null;
            }

            /*Default Role*/
            UserRole newRole = new UserRole();
            newRole.UserId = userRegistered.UserId;
            newRole.RoleId = 2;
            await _userServices.UpdateUser(newRole);

            /*User Cart*/
            CartOrder cart = new CartOrder();
            cart.UserId = userRegistered.UserId;
            cart.Date = DateTime.UtcNow;
            await _cartServices.CreateCartOrder(cart);

            UserBasicDto resultUser = new UserBasicDto();
            resultUser = _mapper.Map<UserBasicDto>(userRegistered);

            return resultUser;
        }
    }
}
