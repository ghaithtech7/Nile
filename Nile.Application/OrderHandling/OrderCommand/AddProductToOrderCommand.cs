
namespace Nile.Application.OrderHandling.OrderCommand
{
    public class AddProductToOrderCommand : IRequest<AddOrderDto>
    {
        public decimal TotalPrice { get; set; }
        public DateTime CheckoutDate { get; set; }
        public int UserId { get; set; }
        public AddProductToOrderCommand(decimal totalPrice, 
            DateTime checkoutDate, 
            int userId)
        {
            TotalPrice = totalPrice;
            CheckoutDate = checkoutDate;
            UserId = userId;
        }
    }
}
