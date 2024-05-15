using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Category;
using api.Dtos.Product;
using api.Entity;

namespace api.Mappers
{
    public static class ProductMappers
    {
        public static ProductDto ToProductDto(this Product product)
        {
            return new ProductDto
            {
                CategoryId = product.CategoryId,
                Description = product.Description,
                Inventory = product.Inventory,
                Price = product.Price,
                ProductName = product.ProductName,
                ProductId = product.ProductId,
                Photos = product.Photos.Select(p => p.ToPhotoDto()).ToList()
            };
        }
        public static CreateProductDto ToCreateProductDto(this Product product)
        {
            return new CreateProductDto
            {
                CategoryId = product.CategoryId,
                Description = product.Description,
                Inventory = product.Inventory,
                Price = product.Price,
                ProductName = product.ProductName,
            };
        }
        public static Product ToProduct(this CreateProductDto productDto)
        {
            return new Product
            {
                CategoryId = productDto.CategoryId,
                Description = productDto.Description,
                Inventory = productDto.Inventory,
                Price = productDto.Price,
                ProductName = productDto.ProductName,
            };
        }
        public static List<ProductDto> MapToDtos(this List<Product> products)
        {
            if (products == null)
            {
                return new List<ProductDto>();
            }

            return products.Select(product => new ProductDto
            {
                ProductId = product.ProductId,
                CategoryId = product.CategoryId,
                Description = product.Description,
                Inventory = product.Inventory,
                Price = product.Price,
                ProductName = product.ProductName,
                Photos = product.Photos.Select(p => p.ToPhotoDto()).ToList()
            }).ToList();
        }
    }
}