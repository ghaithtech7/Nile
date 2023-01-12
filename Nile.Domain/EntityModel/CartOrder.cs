
namespace Nile.Domain.EntityModel
{
    public class CartOrder
    {
        public int CartId { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalPrice { get; set; }

        public int? Id { get; set; }
        public virtual User User { get; set; }

        public List<ProductsOfCartOrder> ProductsOfCartOrders { get; set; }
    }
}
