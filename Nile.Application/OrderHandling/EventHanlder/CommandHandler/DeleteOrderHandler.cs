
using Nile.Application.OrderHandling.OrderCommand;
using Nile.Application.Services.OrderServices;

namespace Nile.Application.OrderHandling.EventHanlder.CommandHandler
{
    public class DeleteOrderHandler : IRequestHandler<DeleteOrderCommand, bool>
    {
        private readonly IOrderServices _orderServices;
        private readonly IMapper _mapper;
        public DeleteOrderHandler(IOrderServices orderServices, IMapper mapper)
        {
            _orderServices = orderServices;
            _mapper = mapper;
        }

        public async Task<bool> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            int result = await _orderServices.DeleteOrder(request.OrderId);
            if(result == 0)
            {
                return false;
            }
            return true;
        }
    }
}
