
using MediatR;
using Nile.Application.DtoModels;

namespace Nile.Application.Query.ForUser
{
    public class LoginCredentialQuery : IRequest<string>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public LoginCredentialQuery(string email, string password)
        {
            this.Email = email;
            this.Password = password;
        }
    }
}
