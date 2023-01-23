
using Nile.Domain.EntityModel;

namespace Nile.Application.UserApplication.Queries
{
    public record GetUserByIdQuery : IRequest<User>
    {
        public int UserId { get; }
        public GetUserByIdQuery(int id)
        {
            UserId = id;
        }
    }
}
