using Novitec.Application.Interfaces;
using Novitec.Domains.Entities;

using System.Data.SqlClient;

namespace Novitec.Infrastructure.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly string _connectionString;
        
        public ProductRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<bool> CreateProductAsync(Product product)
        {
            return false;
        }

        public async Task<bool> UpdateProductAsync(int id)
        {
            return false;
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            return false;
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return null;
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return null;
        }
    }
}
