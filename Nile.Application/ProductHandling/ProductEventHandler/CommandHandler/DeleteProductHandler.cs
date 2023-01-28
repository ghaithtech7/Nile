
using Nile.Application.ProductHandling.ProductCommand;
using Nile.Application.Services.ProductServices;

namespace Nile.Application.ProductHandling.ProductEventHandler.CommandHandler
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand, bool>
    {
        private readonly IProductServies _productServices;
        public DeleteProductHandler(IProductServies productServices)
        {
            _productServices = productServices;
        }

        public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            int result = await _productServices.DeleteProduct(request.ProductId);
            if (result == 0)
            {
                return false;
            }
            return true;
        }
    }
}
