/*
using MediatR;*/
using Nile.Application.Command.UserCommand;
using Nile.Application.UserServicves;
using Nile.Domain.EntityModel;

namespace Nile.Application.Handler.CommandHandler.ForUser
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, int>
    {
        private readonly IUserServices _userServices;
        public DeleteUserHandler(IUserServices userServices)
        {
            _userServices = userServices;
        }

        public async Task<int> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            User user = await _userServices.GetUserById(request.Id);
            if (user == null)
            {
                return 0;
            }
            int result = await _userServices.DeleteUser(user);
            return result;
        }
    }
}
