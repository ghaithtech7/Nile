
using Nile.Domain.EntityModel;

namespace Nile.Application.ProductHandling.ProductCommand
{
    public class CreateProductCommand : IRequest<CreateProductDto>
    {
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string ProductType { get; set; }
        public decimal ProductPrice { get; set; }
        public int Qty { get; set; }
        public CreateProductCommand(string productName, string productDescription, string productType, decimal productPrice, int qty)
        {
            ProductName = productName;
            ProductDescription = productDescription;
            ProductType = productType;
            ProductPrice = productPrice;
            Qty = qty;
        }
    }
}
