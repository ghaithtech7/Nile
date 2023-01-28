
using Nile.Domain.EntityModel;

namespace Nile.Application.CartOrderHandling.CartOrderCommand
{
    public class AddProductToCartCommand : IRequest<Product>
    {
        public int CartId { get; set; }
        public int ProductId { get; set; }
        public AddProductToCartCommand(int cartId, int productId)
        {
            CartId = cartId;
            ProductId = productId;
        }
    }
}
