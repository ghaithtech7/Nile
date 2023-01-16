
global using AutoMapper;
global using MediatR;
using Nile.Application.Command.UserCommand;
using Nile.Application.DtoModels;
using Nile.Application.UserServicves;
using Nile.Domain.EntityModel;

namespace Nile.Application.Handler.CommandHandler.ForUser
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, UserBasicDto>
    {
        private readonly IUserServices _userServices;
        private readonly IMapper _mapper;
        public CreateUserHandler(IUserServices userServices, IMapper mapper)
        {
            _userServices = userServices;
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
            UserBasicDto resultUser = new UserBasicDto();
            resultUser = _mapper.Map<UserBasicDto>(userRegistered);

            return resultUser;
        }
    }
}
