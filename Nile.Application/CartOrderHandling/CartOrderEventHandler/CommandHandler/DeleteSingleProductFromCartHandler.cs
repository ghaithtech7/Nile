
using Nile.Application.CartOrderHandling.CartOrderCommand;
using Nile.Application.Services.CartServices;

namespace Nile.Application.CartOrderHandling.CartOrderEventHandler.CommandHandler
{
    public class DeleteSingleProductFromCartHandler : IRequestHandler<DeleteSingleProductFromCartCommand, bool>
    {
        private readonly ICartServices _cartServices;
        public DeleteSingleProductFromCartHandler(ICartServices cartServices)
        {
            _cartServices = cartServices;
        }

        public async Task<bool> Handle(DeleteSingleProductFromCartCommand request, CancellationToken cancellationToken)
        {
            var result = await _cartServices.DeleteSingleProductFromCart(request.CartId, request.ProductId);
            if(result == 0)
            {
                return false;
            }
            return true;
        }
    }
}
