using api.Dtos.Photo;
using api.Dtos.Product;
using api.Entity;

namespace api.Interfaces
{
    public interface IPhotoRepository
    {
        public Task<Photo?> Create(Photo photo);
        public Task<Photo?> Update(long photoId, UpdatePhotoDto photoDto);
        public Task<Photo?> Delete(long photoId, string filePath);
        public Task<bool> DeleteAll(long productId);
    }
}
