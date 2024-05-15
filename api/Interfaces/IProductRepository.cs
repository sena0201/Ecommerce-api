using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Product;
using api.Entity;
using api.Helpers;

namespace api.Interfaces
{
    public interface IProductRepository
    {
        public Task<List<Product>> GetAll(ProductQueryObject query);
        public Task<Product?> GetById(long productId);
        public Task<Product?> Create(Product product);
        public Task<Product?> Update(long productId, UpdateProductDto productDto);
        public Task<Product?> Delete(long productId);
        public int GetCount(ProductQueryObject query);
    }
}