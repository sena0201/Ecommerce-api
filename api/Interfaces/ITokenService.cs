using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.User;

namespace api.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(LoginDto loginDto);
    }
}