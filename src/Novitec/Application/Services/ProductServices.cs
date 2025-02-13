using Novitec.Application.Interfaces;
using Novitec.Domains.Entities;
using Novitec.Presentation.Requests; 

using System.Text.RegularExpressions;

namespace Novitec.Application.Services
{
    public class ProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<bool> CreateProductAsync(ProductRequest product)
        {
            ValidateProduct(product);
            return await _productRepository.CreateProductAsync(product);
        }

        public async Task<bool> UpdateProductAsync(ProductRequest product)
        {
            ValidateProduct(product);
            return await _productRepository.UpdateProductAsync(product);
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            return await _productRepository.DeleteProductAsync(id);
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _productRepository.GetProductByIdAsync(id);
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _productRepository.GetProductsAsync();
        }

        private static void ValidateProduct(ProductRequest product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }
            if (string.IsNullOrEmpty(product.Name))
            {
                throw new ArgumentException("Name cannot be empty");
            }
            if (product.Stock < 0)
            {
                throw new ArgumentException("Stock cannot be negative");
            }
            if (product.Price <= 0)
            {
                throw new ArgumentException("Price cannot be negative");
            }
        }
    }
}
