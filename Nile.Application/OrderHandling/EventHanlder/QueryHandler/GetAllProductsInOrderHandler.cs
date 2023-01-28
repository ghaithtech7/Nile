
using Nile.Application.OrderHandling.OrderQueries;
using Nile.Application.Services.OrderServices;
using Nile.Domain.EntityModel;

namespace Nile.Application.OrderHandling.EventHanlder.QueryHandler
{
    public class GetAllProductsInOrderHandler : IRequestHandler<GetAllProductsInOrderQuery, Order>
    {
        private readonly IOrderServices _orderServices;
        public GetAllProductsInOrderHandler(IOrderServices orderServices)
        {
            _orderServices = orderServices;
        }

        public async Task<Order> Handle(GetAllProductsInOrderQuery request, CancellationToken cancellationToken)
        {
            Order order = await _orderServices.GetOrderById(request.OrderId);
            return order;
        }
    }
}
