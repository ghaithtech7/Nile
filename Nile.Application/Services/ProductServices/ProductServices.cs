using Microsoft.EntityFrameworkCore;
using Nile.Domain.EntityModel;
using Nile.Infrastructure.Context;

namespace Nile.Application.Services.ProductServices
{
    public class ProductServices : IProductServies
    {
        private readonly IApplicationDbContext _context;
        public ProductServices(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Product> CreateProduct(Product product)
        {
            try
            {
                _context.Products.Add(product);
                await _context.SaveChangesAsync();
                return product;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<int> DeleteProduct(int productId)
        {
            try
            {
                Product product = await GetProductById(productId);
                _context.Products.Remove(product);
                int result = await _context.SaveChangesAsync();
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<Product>> GetAllProducts()
        {
            try
            {
                List<Product> products = await _context.Products.ToListAsync();
                return products;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Product> GetProductById(int productId)
        {
            try
            {
                Product product = await _context.Products
                                .Where(p => p.ProductId == productId)
                                .FirstOrDefaultAsync();
                return product;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task UpdateProduct(Product product)
        {
            try
            {
                _context.Products.Update(product);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
