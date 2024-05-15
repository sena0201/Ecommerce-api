using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Category;
using api.Entity;
using api.Helpers;
using api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDBContext _context;
        public CategoryRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<Category?> Create(Category category)
        {
            var c = await _context.Categories.FirstOrDefaultAsync(c => c.CategoryName == category.CategoryName);
            if (c != null)
            {
                return null;
            }

            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<Category?> Delete(long categoryId)
        {
            var c = await _context.Categories.FirstOrDefaultAsync(c => c.CategoryId == categoryId);
            if (c == null)
            {
                return null;
            }
            _context.Categories.Remove(c);
            await _context.SaveChangesAsync();
            return c;
        }

        public async Task<List<Category>> GetAll(CategoryQueryObject query)
        {
            var categories = _context.Categories.Include(c => c.Products).AsQueryable();
            if (!string.IsNullOrWhiteSpace(query.searchValue))
            {
                categories = _context.Categories.Where(c => c.CategoryName!.Contains(query.searchValue));
            }
            var nextNumber = (query.page - 1) * query.pageSize;
            return await categories.Skip(nextNumber).Take(query.pageSize).ToListAsync();
        }

        public async Task<List<Category>> GetAll()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category?> GetById(long categoryId)
        {
            var category = await _context.Categories.Include(c => c.Products).FirstOrDefaultAsync(c => c.CategoryId == categoryId);
            if (category == null) { return null; }
            return category;
        }

        public int GetCount(CategoryQueryObject query)
        {
            var categories = _context.Categories.Include(c => c.Products).AsQueryable();
            if (!string.IsNullOrWhiteSpace(query.searchValue))
            {
                categories = _context.Categories.Where(c => c.CategoryName!.Contains(query.searchValue));
            }
            return categories.Count();
        }

        public async Task<Category?> Update(long categoryId, UpdateCategoryDto categoryDto)
        {
            var c = await _context.Categories.FirstOrDefaultAsync(c => c.CategoryId == categoryId);
            if (c == null)
            {
                return null;
            }
            c.CategoryName = categoryDto.CategoryName;
            c.Description = categoryDto.Description;
            c.SupplierId = categoryDto.SupplierId;
            await _context.SaveChangesAsync();
            return c;
        }
    }
}