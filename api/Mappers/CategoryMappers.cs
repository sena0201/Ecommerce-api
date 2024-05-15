using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Category;
using api.Entity;

namespace api.Mappers
{
    public static class CategoryMappers
    {
        public static CategoryDto ToCategoryDto(this Category category)
        {
            return new CategoryDto
            {
                CategoryName = category.CategoryName,
                Description = category.Description,
                SupplierId = category.SupplierId,
                products = category.Products.Select(p => p.ToProductDto()).ToList(),
            };
        }
        public static CreateCategoryDto ToCreateCategoryDto(this Category category)
        {
            return new CreateCategoryDto
            {
                CategoryName = category.CategoryName,
                Description = category.Description,
                SupplierId = category.SupplierId,
            };
        }
        public static Category ToCategory(this CreateCategoryDto categoryDto)
        {
            return new Category
            {
                CategoryName = categoryDto.CategoryName,
                SupplierId = categoryDto.SupplierId,
                Description = categoryDto.Description
            };
        }
        public static List<CategoryDto> MapToDtos(this List<Category> categories)
        {
            if (categories == null)
            {
                return new List<CategoryDto>();
            }

            return categories.Select(category => new CategoryDto
            {
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName,
                Description = category.Description,
                SupplierId = category.SupplierId,
                products = category.Products.Select(p => p.ToProductDto()).ToList()
            }).ToList();
        }
    }
}