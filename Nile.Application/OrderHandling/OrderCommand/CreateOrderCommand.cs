
namespace Nile.Application.OrderHandling.OrderCommand
{
    public class CreateOrderCommand : IRequest<AddOrderDto>
    {
        public int UserId { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime CheckoutDate { get; set; }
        public CreateOrderCommand(int userId, decimal totalPrice, DateTime checkoutDate)
        {
            UserId = userId;
            TotalPrice = totalPrice;
            CheckoutDate = checkoutDate;
        }
    }
}
