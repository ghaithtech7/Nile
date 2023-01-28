
using Nile.Application.CartOrderHandling.CartOrderCommand;
using Nile.Application.Services.CartServices;
using Nile.Domain.EntityModel;

namespace Nile.Application.CartOrderHandling.CartOrderEventHandler.CommandHandler
{
    public class CreateCartOrderHandler : IRequestHandler<CreateCartOrderCommand, CartOrder>
    {
        private readonly ICartServices _cartServices;
        private readonly IMapper _mapper;
        public CreateCartOrderHandler(ICartServices cartServices, IMapper mapper)
        {
            _cartServices = cartServices;
            _mapper = mapper;
        }

        public async Task<CartOrder> Handle(CreateCartOrderCommand request, CancellationToken cancellationToken)
        {
            /*First Create The Cart*/
            CartOrder cart = new CartOrder();
            cart.UserId = request.UserID;
            cart.TotalPrice = request.TotalPrice;
            cart.Date = DateTime.UtcNow;
            await _cartServices.CreateCartOrder(cart);

            /*Then Add All Chosen Products*/
            await _cartServices.AddAllProductsToCart(request.ProductsOfCartOrdersId);

            return cart;
        }
    }
}
