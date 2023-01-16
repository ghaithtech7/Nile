
using Nile.Domain.EntityModel;

namespace Nile.Application.UserServicves
{
    public interface IUserServices
    {
        bool Authenticate(User user);
        Task<string> GenerateToken(string email, string password);
        Task<User> RegisterUser(User user);
        Task<User> GetUserById(int id);
        Task<List<User>> GetUsers();
        bool CheckPasswordMatch(string password, string confirmPassword);
        string PassowrdHash(string password);
        Task<int> DeleteUser(User user);
        User GetUserByEmail(string email);
    }
}
