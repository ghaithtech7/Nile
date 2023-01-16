using AutoMapper;
using MediatR;
using Nile.Application.Query.ForUser;
using Nile.Application.UserServicves;
using Nile.Domain.EntityModel;

namespace Nile.Application.Handler.QueryHandler.ForUser
{
    public class LoginCredentialHandler : IRequestHandler<LoginCredentialQuery, string>
    {
        private readonly IUserServices _userServices;
        private readonly IMapper _mapper;
        public LoginCredentialHandler(IUserServices userServices, IMapper mapper)
        {
            _userServices = userServices;
            _mapper = mapper;
        }

        public async Task<string> Handle(LoginCredentialQuery request, CancellationToken cancellationToken)
        {
            User user = _userServices.GetUserByEmail(request.Email);   
            if(user == null)
            {
                return null;
            }
            string HashedPassword = _userServices.PassowrdHash(request.Password);
            if(user.PasswordHash != HashedPassword)
            {
                return "Wrong Password";
            }
            string token = await _userServices.GenerateToken(request.Email, request.Password);
            return token;
        }
    }
}
