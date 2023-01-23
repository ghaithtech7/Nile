
using static Nile.Domain.Enums.Enums;

namespace Nile.Application.UserApp.Commands
{
    public record class AddUserRoleCommand : IRequest<bool>
    {
        public EnumRoles RoleName { get; set; }
        public string Description { get; set; }

        public AddUserRoleCommand(EnumRoles role, string desc)
        {
            RoleName = role;
            Description = desc;
        }
    }
}
