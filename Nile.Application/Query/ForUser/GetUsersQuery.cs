
using MediatR;
using Nile.Domain.EntityModel;

namespace Nile.Application.Query.ForUser
{
    public class GetUsersQuery : IRequest<List<User>>
    {

    }
}
