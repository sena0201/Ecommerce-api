using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.User;
using api.Entity;

namespace api.Mappers
{
    public static class UserMappers
    {
        public static UserDto ToUserDto(this User user)
        {
            return new UserDto
            {
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Photo = user.Photo
            };
        }

        public static User ToUser(this CreateUserDto userDto)
        {
            return new User
            {
                UserName = userDto.UserName,
                Password = userDto.Password,
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Email = userDto.Email,
                PhoneNumber = userDto.PhoneNumber,
                Photo = userDto.Photo
            };
        }
    }
}