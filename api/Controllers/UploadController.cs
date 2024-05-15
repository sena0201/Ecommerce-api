using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Helpers;
using api.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UploadController : ControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IUploadRepository _uploadRepository;

        public UploadController(IWebHostEnvironment webHostEnvironment, IUploadRepository uploadRepository)
        {
            _webHostEnvironment = webHostEnvironment;
            _uploadRepository = uploadRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            try
            {
                if (file != null && file.Length > 0)
                {
                    // Tạo một tên tệp duy nhất cho hình ảnh
                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

                    // Đường dẫn tới thư mục lưu trữ hình ảnh (trong thư mục wwwroot/uploads)
                    var filePath = Path.Combine(_webHostEnvironment.WebRootPath, "uploads", fileName);

                    // Lưu hình ảnh vào đường dẫn đã chỉ định
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }

                    var imageUrl = $"uploads/{fileName}";
                    return Ok(imageUrl);
                }
                return BadRequest("No file uploaded");
            }
            catch (Exception ex)
            {
                // Xử lý lỗi khi tải lên
                return StatusCode(500, ex);
            }
        }

        [HttpDelete("{fileName}")]
        public async Task<IActionResult> Delete([FromRoute] string fileName)
        {
            try
            {
                string decodedUrl = Uri.UnescapeDataString(fileName);
                var check = _uploadRepository.Delete(decodedUrl);
                if (check == false)
                {
                    return NotFound("Khong tim thay");
                }
                return Ok(decodedUrl);
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }
    }
}