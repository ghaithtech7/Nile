
using Nile.Application.ProductHandling.ProductCommand;
using Nile.Application.Services.ProductServices;
using Nile.Domain.EntityModel;

namespace Nile.Application.ProductHandling.ProductEventHandler.CommandHandler
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, CreateProductDto>
    {
        private readonly IProductServies _productServies;
        private readonly IMapper _mapper;
        public CreateProductHandler(IProductServies productServies, IMapper mapper)
        {
            _productServies = productServies;
            _mapper = mapper;
        }

        public async Task<CreateProductDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            Product product = new Product();
            product.ProductName = request.ProductName;
            product.ProductDescription = request.ProductDescription;
            product.ProductType = request.ProductType;
            product.ProductPrice = request.ProductPrice;
            product.Qty = request.Qty;

            Product productResult = await _productServies.CreateProduct(product);

            CreateProductDto result = _mapper.Map<CreateProductDto>(product);
            return result;
        }
    }
}
