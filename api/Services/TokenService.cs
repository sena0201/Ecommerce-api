
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using api.Dtos.User;
using api.Interfaces;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;

namespace api.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _config;
        private readonly SymmetricSecurityKey _key;
        public TokenService(IConfiguration config)
        {
            _config = config;
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:SigningKey"]));
        }
        public string CreateToken(LoginDto loginDto)
        {
            var claims = new List<Claim> {
                new Claim(Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames.GivenName, loginDto.UserName),
                new Claim(Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames.GivenName, loginDto.Password),

            };
            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddSeconds(30),
                SigningCredentials = creds,
                Issuer = _config["JWT:Issuer"],
                Audience = _config["JWT:Audience"]
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}