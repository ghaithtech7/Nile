
using MediatR;
using Nile.Application.DtoModels;

namespace Nile.Application.UserApplication.Queries
{
    public record class LoginCredentialQuery : IRequest<object>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string WindowsAuth { get; set; }
        public LoginCredentialQuery(string email, string password, string windowsAuth)
        {
            Email = email;
            Password = password;
            WindowsAuth = windowsAuth;
        }
    }
}
