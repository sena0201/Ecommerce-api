using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.User;
using api.Entity;
using api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDBContext _context;
        public UserRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<User?> CreateUserAsync(User userModel)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == userModel.UserName);
            if (user != null)
            {
                return null;
            }
            else
            {
                await _context.Users.AddAsync(userModel);
                await _context.SaveChangesAsync();
                return userModel;
            }

        }

        public async Task<User?> DeleteUserAsync(long userId)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserId == userId);
            if (user == null) return null;
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<List<User>> GetAllUser()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User?> GetUserByID(long userId)
        {
            return await _context.Users.FirstOrDefaultAsync(user => user.UserId == userId);
        }

        public async Task<User?> UpdateUserAsync(long userId, UpdateUserDto userDto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserId == userId);
            if (user == null)
            {
                return null;
            }
            user.Password = userDto.Password;
            user.FirstName = userDto.FirstName;
            user.LastName = userDto.LastName;
            user.PhoneNumber = userDto.PhoneNumber;
            user.Photo = userDto.Photo;
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User?> Login(LoginDto loginDto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == loginDto.UserName && u.Password == loginDto.Password);
            if (user == null)
            {
                return null;
            }
            return user;
        }
    }
}