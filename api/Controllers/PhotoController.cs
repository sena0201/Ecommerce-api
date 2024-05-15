using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Photo;
using api.Entity;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PhotoController : ControllerBase
    {
        private readonly IPhotoRepository _photoRepo;
        public PhotoController(IPhotoRepository photoRepo)
        {
            _photoRepo = photoRepo;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePhotoDto photoDto)
        {
            try
            {
                var photo = await _photoRepo.Create(photoDto.ToPhoto());
                if (photo == null)
                {
                    return Conflict();
                }
                return Ok(new ResponsePhotoDto
                {
                    Success = true,
                });
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        [HttpPut("{id:long}")]
        public async Task<IActionResult> Update([FromRoute] long id, [FromBody] UpdatePhotoDto photoDto)
        {
            try
            {
                var photo = await _photoRepo.Update(id, photoDto);
                if (photo == null)
                {
                    return NotFound();
                }
                return Ok(new ResponsePhotoDto
                {
                    Success = true,
                });
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        [HttpDelete("{productId:long}")]
        public async Task<IActionResult> Delete([FromRoute] long productId)
        {
            try
            {
                var photo = await _photoRepo.DeleteAll(productId);
                if (photo == false)
                {
                    return NotFound();
                }

                return Ok(new ResponsePhotoDto
                {
                    Success = true,
                });
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }
    }
}