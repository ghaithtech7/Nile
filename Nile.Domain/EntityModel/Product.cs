using System.ComponentModel.DataAnnotations;

namespace Nile.Domain.EntityModel
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public string ProductType { get; set; }
        public decimal ProductPrice { get; set; }
        public int Qty { get; set; }

        public int? FileId { get; set; }
        public virtual ContentFile ContentFile { get; set; }

        public List<ProductsOfOrder> ProductsOfOrders { get; set; }
        public List<ProductsOfCartOrder> ProductsOfCartOrders { get; set; }
    }
}
