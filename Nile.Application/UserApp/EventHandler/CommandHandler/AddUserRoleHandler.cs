
using Nile.Application.UserApp.Commands;
using Nile.Application.UserServicves;
using Nile.Domain.EntityModel;

namespace Nile.Application.UserApplication.EventHandler.CommandHandler
{
    public class AddUserRoleHandler : IRequestHandler<AddUserRoleCommand, bool>
    {
        private readonly IUserServices _userServices;
        private readonly IMapper _mapper;

        public AddUserRoleHandler(IUserServices userServices, IMapper mapper)
        {
            _userServices = userServices;
            _mapper = mapper;
        }

        public async Task<bool> Handle(AddUserRoleCommand request, CancellationToken cancellationToken)
        {
            Role Role = new Role();
            Role.RoleDescription = request.Description;
            Role.RoleName = request.RoleName;
            await _userServices.CreateRole(Role);
            return true;
        }
    }
}
