using Microsoft.EntityFrameworkCore;
using Nile.Domain.EntityModel;
using Nile.Infrastructure.Context;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;

namespace Nile.Application.Services.CartServices
{
    public class CartServices : ICartServices
    {
        private readonly IApplicationDbContext _context;
        public CartServices(IApplicationDbContext context)
        {
            this._context = context;
        }

        public async Task AddAllProductsToCart(List<int> allProductId)
        {
            try
            {
                foreach(int productId in allProductId)
                {
                    ProductsOfCartOrder element = new ProductsOfCartOrder();
                    element.ProductId = productId;
                    _context.ProductsOfCartOrders.Add(element);
                    _context.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Product> AddSingleProductToCart(int cartId, int productId)
        {
            try
            {
                Product? product = await _context.Products
                    .Where(x => x.ProductId == productId)
                    .FirstOrDefaultAsync();
                if(product == null)
                {
                    return null;
                }
                ProductsOfCartOrder newProductToCart = new ProductsOfCartOrder();
                newProductToCart.ProductId = productId;
                newProductToCart.CartId = cartId;
                _context.ProductsOfCartOrders.Add(newProductToCart);
                await _context.SaveChangesAsync();
                return product;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<int> DeleteAllProductsFromCart(int cartId)
        {
            try
            {
                IEnumerable<ProductsOfCartOrder> all = await _context.ProductsOfCartOrders
                    .Where(x => x.CartId == cartId)
                    .ToListAsync();
                _context.ProductsOfCartOrders.RemoveRange(all);
                var deleted = await _context.SaveChangesAsync();
                return deleted;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<int> DeleteSingleProductFromCart(int cartId, int productId)
        {
            try
            {
                ProductsOfCartOrder product = await _context.ProductsOfCartOrders
                    .Where(x => x.CartId == cartId)
                    .FirstOrDefaultAsync();
                _context.ProductsOfCartOrders.Remove(product);
                var result = await _context.SaveChangesAsync();
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<Product>> GetAllProductsInCart(int cartId)
        {
            try
            {
                List<Product> all = await _context.Products
                    .Include(x => x.ProductsOfCartOrders)
                    .ThenInclude(x => x.CartOrder.CartId == cartId)
                    .ToListAsync();
                return all;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<CartOrder> CreateCartOrder(CartOrder cartOrder)
        {
            try
            {
                _context.CartOrders.Add(cartOrder);
                _context.SaveChanges();
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
