
using MediatR;

namespace Nile.Application.UserApplication.Commands
{
    public record class DeleteUserCommand : IRequest<int>
    {
        public int Id { get; set; }
        public DeleteUserCommand(int id)
        {
            Id = id;
        }
    }
}
