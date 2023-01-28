
using Nile.Application.OrderHandling.OrderCommand;
using Nile.Application.Services.OrderServices;
using Nile.Domain.EntityModel;

namespace Nile.Application.OrderHandling.EventHanlder.CommandHandler
{
    public class CreateOrderHandler : IRequestHandler<CreateOrderCommand, AddOrderDto>
    {
        private readonly IOrderServices _orderServices;
        private readonly IMapper _mapper;
        public CreateOrderHandler(IOrderServices orderServices, IMapper mapper)
        {
            _orderServices = orderServices;
            _mapper = mapper;
        }

        public async Task<AddOrderDto> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            Order order = new Order();
            order.TotalPrice = request.TotalPrice;
            order.CheckoutDate = request.CheckoutDate;
            order.UserId = request.UserId;

            Order result = await _orderServices.CreateOrder(order);
            return _mapper.Map<AddOrderDto>(result);
        }
    }
}
