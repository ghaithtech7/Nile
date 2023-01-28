
using Nile.Domain.EntityModel;

namespace Nile.Application.CartOrderHandling.CartOrderCommand
{
    public class CreateCartOrderCommand : IRequest<CartOrder>
    {
        public int UserID { get; set; }
        public decimal TotalPrice { get; set; }
        public List<int> ProductsOfCartOrdersId { get; set; }
        public CreateCartOrderCommand(int userID, decimal totalPrice, List<int> productsOfCartOrdersId)
        {
            UserID = userID;
            TotalPrice = totalPrice;
            ProductsOfCartOrdersId = productsOfCartOrdersId;
        }
    }
}
