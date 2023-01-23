
using Nile.Domain.EntityModel;
using static Nile.Domain.Enums.Enums;

namespace Nile.Application.UserApp.Commands
{
    public class UpdateUserRoleCommand : IRequest<UserRole>
    {
        public int UserId { get; set; }
        public EnumRoles RoleName { get; set; }
        public UpdateUserRoleCommand(int userId, EnumRoles roleName)
        {
            UserId = userId;
            RoleName = roleName;
        }
    }
}
