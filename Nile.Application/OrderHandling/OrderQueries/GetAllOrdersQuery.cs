
using Nile.Domain.EntityModel;

namespace Nile.Application.OrderHandling.OrderQueries
{
    public class GetAllOrdersQuery : IRequest<List<Order>>
    {
        public int UserId { get; set; }
        public GetAllOrdersQuery(int userId)
        {
            UserId = userId;
        }
    }
}
