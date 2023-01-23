
using Nile.Domain.EntityModel;
using static Nile.Domain.Enums.Enums;

namespace Nile.Application.UserServicves
{
    public interface IUserServices
    {
        Task<User> RegisterUser(User user);
        Task<List<User>> GetUsers();
        User GetUserByEmail(string email);
        Task<User> GetUserById(int id);
        Task<Role> GetRoleByRoleName(EnumRoles roleName);
        Task<int> DeleteUser(User user);
        Task UpdateUser();
        bool CheckPasswordMatch(string password, string confirmPassword);
        string PassowrdHash(string password);
        bool Authenticate(User user);
        Task<object> GenerateToken(string email, string password);
        Task<Role> CreateRole(Role role);
        Task<UserRole> UpdateUser(UserRole newRole);
    }
}
