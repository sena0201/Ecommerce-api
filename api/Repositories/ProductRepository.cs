using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Product;
using api.Entity;
using api.Helpers;
using api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDBContext _context;
        public ProductRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<Product?> Create(Product product)
        {
            var p = await _context.Products.FirstOrDefaultAsync(p => p.ProductName == product.ProductName);
            if (p != null)
            {
                return null;
            }

            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            return product;
        }

        public async Task<Product?> Delete(long productId)
        {
            var p = await _context.Products.FirstOrDefaultAsync(p => p.ProductId == productId);
            if (p == null)
            {
                return null;
            }
            _context.Products.Remove(p);
            await _context.SaveChangesAsync();
            return p;
        }

        public async Task<List<Product>> GetAll(ProductQueryObject query)
        {
            var products = _context.Products.Include(p => p.Photos).AsQueryable();
            if (!string.IsNullOrWhiteSpace(query.searchValue))
            {
                products = _context.Products.Where(p => p.ProductName!.Contains(query.searchValue));
            }
            var nextNumber = (query.page - 1) * query.pageSize;
            return await products.Skip(nextNumber).Take(query.pageSize).ToListAsync();
        }

        public async Task<Product?> GetById(long productId)
        {
            var product = await _context.Products.Include(p => p.Photos).FirstOrDefaultAsync(c => c.ProductId == productId);
            if (product == null) { return null; }
            return product;
        }

        public int GetCount(ProductQueryObject query)
        {
            var products = _context.Products.Include(p => p.Photos).AsQueryable();
            if (!string.IsNullOrWhiteSpace(query.searchValue))
            {
                products = _context.Products.Where(p => p.ProductName!.Contains(query.searchValue));
            }
            return products.Count();
        }

        public async Task<Product?> Update(long productId, UpdateProductDto productDto)
        {
            var p = await _context.Products.FirstOrDefaultAsync(p => p.ProductId == productId);
            if (p == null)
            {
                return null;
            }
            p.ProductName = productDto.ProductName;
            p.Price = productDto.Price;
            p.Description = productDto.Description;
            p.Inventory = productDto.Inventory;
            p.CategoryId = productDto.CategoryId;

            await _context.SaveChangesAsync();
            return p;
        }
    }
}