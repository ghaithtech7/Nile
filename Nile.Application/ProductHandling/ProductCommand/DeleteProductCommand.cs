
namespace Nile.Application.ProductHandling.ProductCommand
{
    public class DeleteProductCommand : IRequest<bool>
    {
        public int ProductId { get; set; }
        public DeleteProductCommand(int productId)
        {
            ProductId = productId;
        }
    }
}
