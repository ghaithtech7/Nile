using Microsoft.EntityFrameworkCore;
using Nile.Domain.EntityModel;
using Nile.Infrastructure.Context;

namespace Nile.Application.Services.OrderServices
{
    public class OrderServices : IOrderServices
    {
        private readonly IApplicationDbContext _context;
        public OrderServices(IApplicationDbContext context)
        {
            this._context = context;
        }

        public async Task<Order> CreateOrder(Order order)
        {
            try
            {
                _context.Orders.Add(order);
                await _context.SaveChangesAsync();
                return order;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<int> DeleteOrder(int orderId)
        {
            try
            {
                Order order = await GetOrderById(orderId);
                _context.Orders.Remove(order);
                int result = await _context.SaveChangesAsync();
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<Order>> GetAllOrders(int userId)
        {
            try
            {
                List<Order> orders = await _context.Orders
                    .Where(x => x.UserId == userId)
                                .Include(x => x.ProductsOfOrders)
                                .ToListAsync();
                return orders;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Order> GetOrderById(int orderId)
        {
            try
            {
                Order? result = await _context.Orders
                            .Include(x => x.ProductsOfOrders)
                            .FirstOrDefaultAsync();
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task UpdateOrder(Order order)
        {
            try
            {
                _context.Orders.Update(order);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
