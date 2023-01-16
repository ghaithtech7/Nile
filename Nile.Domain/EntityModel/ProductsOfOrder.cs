using System.ComponentModel.DataAnnotations;

namespace Nile.Domain.EntityModel
{
    public class ProductsOfOrder
    {
        [Key]
        public int ProductsOfOrderId { get; set;}

        public int? OrderId { get; set; }
        public Order Order { get; set; }

        public int? ProductId { get; set; }
        public Product? Product { get; set; }
    }
}
