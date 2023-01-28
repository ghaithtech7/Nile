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
        Task AddAllProductsToCart(List<int> allProductId);

        Task<int> DeleteAllProductsFromCart(int cartId);
        Task<int> DeleteSingleProductFromCart(int cartId, int productId);
        Task<Product> AddSingleProductToCart(int cartId, int productId);
        Task<List<Product>> GetAllProductsInCart(int cartId);
    }
}