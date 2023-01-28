
namespace Nile.Application.OrderHandling.OrderCommand
{
    public class DeleteOrderCommand : IRequest<bool>
    {
        public int OrderId { get; set; }
        public DeleteOrderCommand(int orderId)
        {
            OrderId = orderId;
        }
    }
}
