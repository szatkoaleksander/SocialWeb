using System;
using SocialWeb.Infrastructure.DTO;

namespace SocialWeb.Infrastructure.Services.Jwt
{
    public class JwtHandler : IJwtHandler
    {
        public JwtDto CreateToken(Guid userId, string role)
        {
            throw new NotImplementedException();
        }
    }
}