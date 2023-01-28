
namespace Nile.Application.CartOrderHandling.CartOrderCommand
{
    public class DeleteSingleProductFromCartCommand : IRequest<bool>
    {
        public int CartId { get; set; }
        public int ProductId { get; set; }
        public DeleteSingleProductFromCartCommand(int productId, int cartId)
        {
            ProductId = productId;
            CartId = cartId;
        }
    }
}
