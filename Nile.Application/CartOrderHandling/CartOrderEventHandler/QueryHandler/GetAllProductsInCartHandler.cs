
using Nile.Application.CartOrderHandling.CartOrderQuery;
using Nile.Application.Services.CartServices;
using Nile.Domain.EntityModel;

namespace Nile.Application.CartOrderHandling.CartOrderEventHandler.QueryHandler
{
    public class GetAllProductsInCartHandler : IRequestHandler<GetAllProductsInCartQuery, List<Product>>
    {
        private readonly ICartServices _cartServices;
        public GetAllProductsInCartHandler(ICartServices cartServices)
        {
            _cartServices = cartServices;
        }

        public async Task<List<Product>> Handle(GetAllProductsInCartQuery request, CancellationToken cancellationToken)
        {
            List<Product> products = await _cartServices.GetAllProductsInCart(request.CartId);
            return products;
        }
    }
}
