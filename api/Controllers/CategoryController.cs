using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Category;
using api.Entity;
using api.Helpers;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepo;
        public CategoryController(ICategoryRepository categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] CategoryQueryObject query)
        {
            try
            {
                List<Category> categories = await _categoryRepo.GetAll(query);
                if (categories == null)
                {
                    return NotFound();
                }
                var count = _categoryRepo.GetCount(query);
                var pageCount = count % query.pageSize == 0 ? count / query.pageSize : count / query.pageSize + 1;
                return Ok(new ResponseCategoryDto
                {
                    page = query.page,
                    pageSize = query.pageSize,
                    pageCount = pageCount,
                    categories = categories.MapToDtos()
                });
            }
            catch (Exception e) { return BadRequest(e); }
        }
        [HttpGet]
        [Route("/api/allcategories")]
        public async Task<IActionResult> GetAllCategories()
        {
            try
            {
                List<Category> categories = await _categoryRepo.GetAll();
                if (categories == null)
                {
                    return NotFound();
                }
                return Ok(categories);
            }
            catch (Exception e) { return BadRequest(e); }
        }
        [HttpGet("{id:long}")]
        public async Task<IActionResult> GetById([FromRoute] long id)
        {
            try
            {
                var category = await _categoryRepo.GetById(id);
                if (category == null) { return NotFound(); }
                return Ok(category);
            }
            catch (Exception e) { return BadRequest(e); }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCategoryDto categoryDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                var category = await _categoryRepo.Create(categoryDto.ToCategory());
                if (category == null)
                {
                    return Conflict();
                }
                return CreatedAtAction(nameof(GetById), new { id = category.CategoryId }, category.ToCreateCategoryDto());
            }
            catch (Exception e) { return BadRequest(e); }
        }
        [HttpPut("{id:long}")]
        public async Task<IActionResult> Update([FromRoute] long id, [FromBody] UpdateCategoryDto categoryDto)
        {
            try
            {
                var category = await _categoryRepo.Update(id, categoryDto);
                if (category == null)
                {
                    return NotFound();
                }
                return Ok(category);
            }
            catch (Exception e) { return BadRequest(e); }
        }
        [HttpDelete("{id:long}")]
        public async Task<IActionResult> Delete([FromRoute] long id)
        {
            try
            {
                var category = await _categoryRepo.Delete(id);
                if (category == null)
                {
                    return NotFound();
                }
                return Ok(category);
            }
            catch (Exception e) { return BadRequest(e); }
        }
    }
}