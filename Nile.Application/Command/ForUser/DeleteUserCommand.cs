
using MediatR;

namespace Nile.Application.Command.UserCommand
{
    public class DeleteUserCommand : IRequest<int>
    {
        public int Id { get; set; }
        public DeleteUserCommand(int id)
        {
            Id = id;
        }
    }
}
