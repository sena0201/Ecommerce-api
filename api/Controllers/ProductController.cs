using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Photo;
using api.Dtos.Product;
using api.Entity;
using api.Helpers;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase, IController
    {
        private readonly IProductRepository _productRepo;
        private readonly IPhotoRepository _photoRepo;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ProductController(IProductRepository productRepo, IPhotoRepository photoRepo, IWebHostEnvironment webHostEnvironment)
        {
            _productRepo = productRepo;
            _photoRepo = photoRepo;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] ProductQueryObject query)
        {
            try
            {
                List<Product> products = await _productRepo.GetAll(query);
                if (products == null)
                {
                    return NotFound();
                }
                var count = _productRepo.GetCount(query);
                var pageCount = count % query.pageSize == 0 ? count / query.pageSize : count / query.pageSize + 1;
                return Ok(new ResponseProductDto
                {
                    page = query.page,
                    pageSize = query.pageSize,
                    pageCount = pageCount,
                    products = products.MapToDtos()
                });
            }
            catch (Exception e) { return BadRequest(e); }
        }
        [HttpGet("{id:long}")]
        public async Task<IActionResult> GetById([FromRoute] long id)
        {
            try
            {
                var product = await _productRepo.GetById(id);
                if (product == null) { return NotFound(); }
                return Ok(product.ToProductDto());
            }
            catch (Exception e) { return BadRequest(e); }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProductDto productDto)
        {
            try
            {
                var product = await _productRepo.Create(productDto.ToProduct());
                if (product == null)
                {
                    return Conflict(new { message = "loi roi" });
                }
                return CreatedAtAction(nameof(Create), new { id = product.ProductId });
            }
            catch (Exception e) { return StatusCode(500, e); }
        }
        [HttpPut("{id:long}")]
        public async Task<IActionResult> Update([FromRoute] long id, [FromBody] UpdateProductDto productDto)
        {
            try
            {
                var product = await _productRepo.Update(id, productDto);
                if (product == null)
                {
                    return NotFound();
                }
                return Ok(product);
            }
            catch (Exception e) { return BadRequest(e); }
        }
        [HttpDelete("{id:long}")]
        public async Task<IActionResult> Delete([FromRoute] long id)
        {
            try
            {
                var product = await _productRepo.Delete(id);
                if (product == null)
                {
                    return NotFound();
                }
                return Ok(product);
            }
            catch (Exception e) { return BadRequest(e); }
        }
    }
}