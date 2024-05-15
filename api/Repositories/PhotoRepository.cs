using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Photo;
using api.Entity;
using api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class PhotoRepository : IPhotoRepository
    {
        private readonly ApplicationDBContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public PhotoRepository(ApplicationDBContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task<Photo?> Create(Photo photo)
        {
            var p = await _context.Photos.FirstOrDefaultAsync(p => p.Url!.Equals(photo.Url));
            if (p != null)
            {
                return null;
            }
            await _context.Photos.AddAsync(photo);
            await _context.SaveChangesAsync();
            return photo;
        }

        public async Task<Photo?> Delete(long photoId, string filePath)
        {
            var photo = await _context.Photos.FirstOrDefaultAsync(p => p.PhotoId == photoId);
            if (photo == null)
            {
                return null;
            }
            var wwwRootPath = _webHostEnvironment.WebRootPath;
            var path = new Uri(filePath).LocalPath;
            File.Delete(wwwRootPath + path);
            _context.Photos.Remove(photo);
            await _context.SaveChangesAsync();
            return photo;
        }

        public async Task<bool> DeleteAll(long productId)
        {
            var photos = _context.Photos.Where(p => p.ProductId == productId);
            if (photos.Count() == 0)
                return false;
            foreach (var photo in photos)
            {
                _context.Photos.Remove(photo);
            }
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Photo?> Update(long photoId, UpdatePhotoDto photoDto)
        {
            var photo = await _context.Photos.FirstOrDefaultAsync(p => p.PhotoId == photoId);
            if (photo == null)
            {
                return null;
            }
            photo.Url = photoDto.Url;
            return photo;
        }
    }
}