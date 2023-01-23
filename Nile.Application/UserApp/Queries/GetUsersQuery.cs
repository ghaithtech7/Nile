
using MediatR;
using Nile.Domain.EntityModel;

namespace Nile.Application.UserApplication.Queries
{
    public record class GetUsersQuery : IRequest<List<User>>
    {

    }
}
