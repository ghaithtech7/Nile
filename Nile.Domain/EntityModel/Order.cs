using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nile.Domain.EntityModel
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public decimal TotalPrice { get; set;}
        public DateTime CheckoutDate { get; set; }

        public int? UserId { get; set; }
        public virtual User? User { get; set; }

        public virtual Payment Payment { get; set; }

        public List<ProductsOfOrder> ProductsOfOrders { get; set; }
    }
}
