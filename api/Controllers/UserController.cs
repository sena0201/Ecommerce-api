using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.User;
using api.Interfaces;
using Microsoft.AspNetCore.Mvc;
using api.Mappers;
using api.Helpers;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepo;
        private readonly ITokenService _tokenService;

        public UserController(IUserRepository userRepo, ITokenService tokenService)
        {
            _userRepo = userRepo;
            _tokenService = tokenService;
        }

        /*        [HttpGet]
                public async Task<IActionResult> GetAllUser()
                {
                    try
                    {
                        return Ok(await _userRepo.GetAllUser());
                    }
                    catch (Exception e)
                    {
                        return StatusCode(500, e);
                    }
                }*/

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserDto userDto)
        {
            try
            {
                var user = await _userRepo.CreateUserAsync(userDto.ToUser());
                if (user == null) return StatusCode(409);
                return StatusCode(201, new RegisterDto { Success = true, Message = "Register success!" });
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            try
            {
                var user = await _userRepo.Login(loginDto);
                if (user == null) return Unauthorized("Invalid username or Password is incorrect");
                return Ok(new ResponseDto
                {
                    username = user.UserName,
                    firstname = user.FirstName,
                    lastname = user.LastName,
                    photo = user.Photo,
                    token = _tokenService.CreateToken(loginDto),
                    userId = user.UserId
                });

            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }


        [HttpGet("{userId:long}")]
        public async Task<IActionResult> GetUserById([FromRoute] long userId)
        {
            try
            {
                var user = await _userRepo.GetUserByID(userId);
                if (user == null) return NotFound();
                return Ok(user);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        [HttpPut("{userId:long}")]
        public async Task<IActionResult> UpdateUser([FromRoute] long userId, [FromBody] UpdateUserDto userDto)
        {
            try
            {
                var user = await _userRepo.UpdateUserAsync(userId, userDto);
                if (user == null) return NotFound();
                return Ok(user);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpDelete("{userId:long}")]
        public async Task<IActionResult> DeleteUser([FromRoute] long userId)
        {
            try
            {
                var user = await _userRepo.DeleteUserAsync(userId);
                if (user == null) return NotFound();
                return Ok(user);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}