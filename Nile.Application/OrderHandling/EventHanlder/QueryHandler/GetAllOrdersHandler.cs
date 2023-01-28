
using Nile.Application.OrderHandling.OrderQueries;
using Nile.Application.Services.OrderServices;
using Nile.Domain.EntityModel;

namespace Nile.Application.OrderHandling.EventHanlder.QueryHandler
{
    public class GetAllOrdersHandler : IRequestHandler<GetAllOrdersQuery, List<Order>>
    {
        private readonly IOrderServices _orderServices;
        public GetAllOrdersHandler(IOrderServices orderServices)
        {
            _orderServices = orderServices;
        }

        public async Task<List<Order>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {
            List<Order> orders = await _orderServices.GetAllOrders(request.UserId);
            return orders;
        }
    }
}
