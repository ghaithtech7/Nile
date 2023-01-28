
using Microsoft.EntityFrameworkCore.Metadata;
using Nile.Application.OrderHandling.OrderCommand;
using Nile.Application.Services.OrderServices;
using Nile.Domain.EntityModel;

namespace Nile.Application.OrderHandling.EventHanlder.CommandHandler
{
    public class AddProductToOrderQuery : IRequestHandler<AddProductToOrderCommand, AddOrderDto>
    {
        private readonly IOrderServices _orderServices;
        private readonly IMapper _mapper;
        public AddProductToOrderQuery(IOrderServices orderServices, IMapper mapper)
        {
            _orderServices = orderServices;
            _mapper = mapper;
        }

        public async Task<AddOrderDto> Handle(AddProductToOrderCommand request, CancellationToken cancellationToken)
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
