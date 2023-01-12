namespace Nile.API.DtoModels
{
    public class UserDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class UserRegisterDto : UserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string ConfirmPassword { get; set; }
    }

    public class LoggedUserDto
    {
        public string Id { get; set; }
        public string UserName { get; set;}
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
