
using Nile.Application.ProductHandling.ProductQueries;
using Nile.Application.Services.ProductServices;
using Nile.Domain.EntityModel;

namespace Nile.Application.ProductHandling.ProductEventHandler.QueryHandler
{
    public class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery, List<Product>>
    {
        private readonly IProductServies _productServices;
        public GetAllProductsHandler(IProductServies productServices)
        {
            _productServices = productServices;
        }

        public async Task<List<Product>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            List<Product> result = await _productServices.GetAllProducts();
            return result;
        }
    }
}
