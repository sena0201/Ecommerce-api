using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Photo;
using api.Entity;

namespace api.Mappers
{
    public static class PhotoMappers
    {
        public static Photo ToPhoto(this PhotoDto photoDto)
        {
            return new Photo
            {
                ProductId = photoDto.ProductId,
                Url = photoDto.Url
            };
        }
        public static Photo ToPhoto(this CreatePhotoDto photoDto)
        {
            return new Photo
            {
                ProductId = photoDto.ProductId,
                Url = photoDto.Url
            };
        }
        public static CreatePhotoDto ToCreatePhotoDto(this Photo photo)
        {
            return new CreatePhotoDto
            {
                ProductId = photo.ProductId,
                Url = photo.Url
            };
        }
        public static PhotoDto ToPhotoDto(this Photo photo)
        {
            return new PhotoDto
            {
                PhotoId = photo.PhotoId,
                ProductId = photo.ProductId,
                Url = photo.Url
            };
        }
        public static List<PhotoDto> MapToDtos(this List<Photo> photos)
        {
            if (photos == null)
            {
                return new List<PhotoDto>();
            }

            return photos.Select(photo => new PhotoDto
            {
                PhotoId = photo.PhotoId,
                ProductId = photo.ProductId,
                Url = photo.Url
            }).ToList();
        }
    }
}