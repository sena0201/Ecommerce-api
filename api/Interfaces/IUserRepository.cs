using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.User;
using api.Entity;

namespace api.Interfaces
{
    public interface IUserRepository
    {
        public Task<List<User>> GetAllUser();
        public Task<User?> GetUserByID(long userId);
        public Task<User?> CreateUserAsync(User userModel);
        public Task<User?> UpdateUserAsync(long userId, UpdateUserDto userDto);
        public Task<User?> DeleteUserAsync(long userId);
        public Task<User?> Login(LoginDto loginDto);
    }
}