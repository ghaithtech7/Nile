

using Nile.Application.CartOrderHandling.CartOrderCommand;
using Nile.Application.Services.CartServices;
using Nile.Domain.EntityModel;

namespace Nile.Application.CartOrderHandling.CartOrderEventHandler.CommandHandler
{
    public class AddProductToCartHandler : IRequestHandler<AddProductToCartCommand, Product>
    {
        private readonly ICartServices _cartServices;
        private readonly IMapper _mapper;
        public AddProductToCartHandler(ICartServices cartServices, IMapper mapper)
        {
            _cartServices = cartServices;
            _mapper = mapper;
        }

        public async Task<Product> Handle(AddProductToCartCommand request, CancellationToken cancellationToken)
        {
            Product result = await _cartServices.AddSingleProductToCart(
                request.CartId, 
                request.ProductId);
            return result;
        }
    }
}
