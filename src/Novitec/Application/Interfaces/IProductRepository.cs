using Novitec.Domains.Entities;
using Novitec.Presentation.Requests;

namespace Novitec.Application.Interfaces
{
    public interface IProductRepository
    {
        Task<bool> CreateProductAsync(ProductRequest product);
        Task<bool> UpdateProductAsync(ProductRequest product);
        Task<bool> DeleteProductAsync(int id);
        Task<Product> GetProductByIdAsync(int id);
        Task<IEnumerable<Product>> GetProductsAsync();
    }
}
