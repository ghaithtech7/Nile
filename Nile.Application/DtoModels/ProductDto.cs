
namespace Nile.Application.DtoModels
{
    public class CreateProductDto
    {
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string ProductType { get; set; }
        public decimal ProductPrice { get; set; }
        public int Qty { get; set; }
    }
}
