using System.ComponentModel.DataAnnotations;
using static Nile.Domain.Enums.Enums;

namespace Nile.Application.DtoModels
{
    public class UserDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class UserRegisterDto : UserDto
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
        
    }

    public class UserBasicDto
    {
        public int UserId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string UserName { get; set; }
        [Phone]
        public string PhoneNumber { get; set; }

    }

    public class UserRoleDto
    {
        public EnumRoles RoleName { get; set; }
        public string? Description { get; set; }
    }

    public class UpdateRoleDto
    {
        public EnumRoles RoleName { get; set; }
        public int UserId { get; set; }
    }
}
