using Microsoft.EntityFrameworkCore;
using Nile.Domain.EntityModel;
using Nile.Infrastructure.Context;

namespace Nile.Application.Services.CartServices
{
    public class CartServices : ICartServices
    {
        private readonly IApplicationDbContext _context;
        public CartServices(IApplicationDbContext context)
        {
            this._context = context;
        }

        public async Task<CartOrder> CreateCartOrder(CartOrder cartOrder)
        {
            try
            {
                _context.CartOrders.Add(cartOrder);
                await _context.SaveChangesAsync();
                return cartOrder;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<int> DeleteCartOrder(CartOrder cartOrder)
        {
            try
            {
                _context.CartOrders.Remove(cartOrder);
                return await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<CartOrder>> GetAllCartOrders()
        {
            try
            {
                List<CartOrder> result = await _context.CartOrders.ToListAsync();
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<CartOrder> GetCartOrderById(int cartOrderId)
        {
            try
            {
                CartOrder result = await _context.CartOrders
                                    .Where(x => x.CartId == cartOrderId)
                                    .FirstOrDefaultAsync();
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task UpdateCartOrder(CartOrder cartOrder)
        {
            try
            {
                _context.CartOrders.Update(cartOrder);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }


}
