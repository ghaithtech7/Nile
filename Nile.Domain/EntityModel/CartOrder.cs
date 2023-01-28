
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nile.Domain.EntityModel
{
    public class CartOrder
    {
        [Key]
        public int CartId { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalPrice { get; set; }

        public int? UserId { get; set; }
        public virtual User? User { get; set; }

        public List<ProductsOfCartOrder> ProductsOfCartOrders { get; set; }
    }
}
