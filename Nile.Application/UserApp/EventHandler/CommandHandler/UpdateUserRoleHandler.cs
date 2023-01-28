
using Nile.Application.UserApp.Commands;
using Nile.Application.UserServicves;
using Nile.Domain.EntityModel;

namespace Nile.Application.UserApp.EventHandler.CommandHandler
{
    public class UpdateUserRoleHandler : IRequestHandler<UpdateUserRoleCommand, UserRole>
    {
        private readonly IUserServices _userServices;
        private readonly IMapper _mapper;
        public UpdateUserRoleHandler(IUserServices userServices, IMapper mapper)
        {
            _userServices = userServices;
            _mapper = mapper;
        }

        public async Task<UserRole> Handle(UpdateUserRoleCommand request, CancellationToken cancellationToken)
        {
            var theRole = await _userServices.GetRoleByRoleName(request.RoleName);
            UserRole newRole = new UserRole();
            newRole.UserId = request.UserId;
            newRole.RoleId = theRole.RoleId;
            
            await _userServices.UpdateUser(newRole);
            return newRole;
        }
    }
}
