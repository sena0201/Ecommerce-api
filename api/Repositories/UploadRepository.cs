using api.Interfaces;
using Microsoft.AspNetCore.Hosting;
using System;

namespace api.Repositories
{
    public class UploadRepository : IUploadRepository
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public UploadRepository(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        public bool Delete(string filePath)
        {
            try
            {
                var wwwRootPath = _webHostEnvironment.WebRootPath;

                File.Delete(wwwRootPath + "/" + filePath);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
