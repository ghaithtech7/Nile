
using MediatR;
using Nile.Application.DtoModels;
using System.ComponentModel.DataAnnotations;

namespace Nile.Application.UserApplication.Commands
{
    public record class CreateUserCommand : IRequest<UserBasicDto>
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string ConfirmPassword { get; set; }
        [Phone]
        public string PhoneNumber { get; set; }
        public CreateUserCommand(
                string firstName,
                string lastName,
                string email,
                string userName,
                string phoneNumber,
                string password,
                string confirmPassword)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            UserName = userName;
            PhoneNumber = phoneNumber;
            Password = password;
            ConfirmPassword = confirmPassword;
        }
    }
}
