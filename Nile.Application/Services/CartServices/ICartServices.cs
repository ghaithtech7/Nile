using Nile.Domain.EntityModel;

namespace Nile.Application.Services.CartServices
{
    public interface ICartServices
    {
        Task<CartOrder> GetCartOrderById(int cartOrderId);
        Task<List<CartOrder>> GetAllCartOrders();
        Task<int> DeleteCartOrder(CartOrder cartOrder);
        Task<CartOrder> CreateCartOrder(CartOrder cartOrder);
        Task UpdateCartOrder(CartOrder cartOrder);
    }
}