using System;
using SocialWeb.Infrastructure.DTO;

namespace SocialWeb.Infrastructure.Services.Jwt
{
    public interface IJwtHandler
    {
         JwtDto CreateToken(Guid userId, string role);
    }
}