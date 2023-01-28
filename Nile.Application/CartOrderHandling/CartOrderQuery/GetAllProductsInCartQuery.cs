
using Nile.Domain.EntityModel;

namespace Nile.Application.CartOrderHandling.CartOrderQuery
{
    public class GetAllProductsInCartQuery : IRequest<List<Product>>
    {
        public int CartId { get; set; }
        public GetAllProductsInCartQuery(int cartId)
        {
            CartId = cartId;
        }
    }
}
