using Novitec.Application.Interfaces;
using Novitec.Domains.Entities;
using Novitec.Presentation.Requests;

using Microsoft.Data.SqlClient;


namespace Novitec.Infrastructure.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly string _connectionString;

        public ProductRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<bool> CreateProductAsync(ProductRequest product)
        {
            var query = "INSERT INTO dbo.Product (Nombre, Stock, Precio) VALUES (@Name, @Stock, @Price)";
            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Name", product.Name);
                command.Parameters.AddWithValue("@Stock", product.Stock);
                command.Parameters.AddWithValue("@Price", product.Price);

                await connection.OpenAsync();
                int result = await command.ExecuteNonQueryAsync();
                return result > 0;
            }
        }

        public async Task<bool> UpdateProductAsync(ProductRequest product)
        {
            var query = "UPDATE dbo.Product SET Nombre = @Name, Stock = @Stock, Precio = @Price WHERE Id = @Id";
            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Id", product.Id);
                command.Parameters.AddWithValue("@Name", product.Name);
                command.Parameters.AddWithValue("@Stock", product.Stock);
                command.Parameters.AddWithValue("@Price", product.Price);
                await connection.OpenAsync();
                int result = await command.ExecuteNonQueryAsync();
                return result > 0;
            }
        }
        
        public async Task<bool> DeleteProductAsync(int id)
        {
            var query = "DELETE FROM dbo.Product WHERE Id = @Id";
            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Id", id);
                await connection.OpenAsync();
                int result = await command.ExecuteNonQueryAsync();
                return result > 0;
            }
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            var query = "SELECT Id, Nombre, Precio, Stock, FechaCreacion FROM dbo.Product WHERE Id = @Id";
            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Id", id);
                await connection.OpenAsync();
                using (var reader = await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        return new Product
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Name = reader["Nombre"].ToString(),
                            Price = Convert.ToDouble(reader["Precio"]),
                            Stock = Convert.ToInt32(reader["Stock"]),
                            CreateDate = Convert.ToDateTime(reader["FechaCreacion"])
                        };
                    }
                    return null;
                }
            }
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            var query = "SELECT Id, Nombre, Precio, Stock, FechaCreacion FROM dbo.Product";
            var products = new List<Product>();
            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand(query, connection))
            {
                await connection.OpenAsync();
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        products.Add(new Product
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Name = reader["Nombre"].ToString(),
                            Price = Convert.ToDouble(reader["Precio"]),
                            Stock = Convert.ToInt32(reader["Stock"]),
                            CreateDate = Convert.ToDateTime(reader["FechaCreacion"])
                        });
                    }
                }
            }
            return products;
        }
    }
}
