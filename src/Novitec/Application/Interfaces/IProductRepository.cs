using Novitec.Domains.Entities;

namespace Novitec.Application.Interfaces
{
    public interface IProductRepository
    {
        Task<bool> CreateProductAsync(Product product);
        Task<bool> UpdateProductAsync(int id);
        Task<bool> DeleteProductAsync(int id);
        Task<Product> GetProductByIdAsync(int id);
        Task<IEnumerable<Product>> GetProductsAsync();
    }
}
