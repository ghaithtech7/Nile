using Nile.Domain.EntityModel;

namespace Nile.Application.Services.OrderServices
{
    public interface IOrderServices
    {
        Task<Order> GetOrderById(int orderId);
        Task<List<Order>> GetAllOrders(int userId);
        Task<int> DeleteOrder(int orderId);
        Task<Order> CreateOrder(Order order);
        Task UpdateOrder(Order order);
    }
}