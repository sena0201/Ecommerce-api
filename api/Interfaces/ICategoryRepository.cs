using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Category;
using api.Entity;
using api.Helpers;

namespace api.Interfaces
{
    public interface ICategoryRepository
    {
        public Task<List<Category>> GetAll(CategoryQueryObject query);
        public Task<List<Category>> GetAll();
        public Task<Category?> GetById(long categoryId);
        public Task<Category?> Create(Category category);
        public Task<Category?> Update(long categoryId, UpdateCategoryDto categoryDto);
        public Task<Category?> Delete(long categoryId);
        public int GetCount(CategoryQueryObject query);
    }
}