
using MediatR;
using Nile.Application.DtoModels;

namespace Nile.Application.Query.ForUser
{
    public class GetUserByIdQuery : IRequest<UserBasicDto>
    {
        public int UserId { get; }
        public GetUserByIdQuery(int id)
        {
            UserId = id;
        }
    }
}
