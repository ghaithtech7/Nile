using Nile.Domain.EntityModel;

namespace Nile.Application.Services.ProductServices
{
    public interface IProductServies
    {
        Task<Product> GetProductById(int productId);
        Task<List<Product>> GetAllProducts();
        Task<int> DeleteProduct(Product product);
        Task<Product> CreateProduct(Product product);
        Task UpdateProduct(Product product);
    }
}