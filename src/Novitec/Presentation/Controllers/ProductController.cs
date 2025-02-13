﻿using Novitec.Application.Interfaces;
using Novitec.Domains.Entities;
using Novitec.Application.Services;

using Microsoft.AspNetCore.Mvc;

namespace Novitec.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController
    {
        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public async Task<bool> CreateProductAsync(Product product)
        {
            return await _productService.CreateProductAsync(product);
        }

        [HttpGet]
        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _productService.GetProductsAsync();
        }

        [HttpGet("GetProductById")]
        public async Task<Product> GetProductByIdAsync(int Id)
        {
            return await _productService.GetProductByIdAsync(Id);
        }


        [HttpPut]
        public async Task<bool> UpdateProductAsync(int Id)
        {
            return await _productService.UpdateProductAsync(Id);
        }

        [HttpDelete]
        public async Task<bool> DeleteProductAsync(int Id)
        {
            return await _productService.DeleteProductAsync(Id);
        }

    }
}
