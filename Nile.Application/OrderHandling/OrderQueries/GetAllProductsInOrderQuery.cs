
using Nile.Domain.EntityModel;

namespace Nile.Application.OrderHandling.OrderQueries
{
    public class GetAllProductsInOrderQuery : IRequest<Order>
    {
        public int OrderId { get; set; }
        public GetAllProductsInOrderQuery(int orderId)
        {
            OrderId = orderId;
        }
    }
}
