using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using SocialWeb.Infrastructure.Commands;
using SocialWeb.Infrastructure.Commands.User;
using SocialWeb.Infrastructure.Extensions;
using SocialWeb.Infrastructure.Services;
using SocialWeb.Infrastructure.Services.Jwt;

namespace SocialWeb.Infrastructure.Handlers.User
{
    public class LoginHandler : ICommandHandler<Login>
    {
        private readonly IUserService _userService;
        private readonly IJwtHandler _jwtHandler;
        private readonly IMemoryCache _cache;

        public LoginHandler(IUserService userService, IJwtHandler jwtHandler, IMemoryCache cache)
        {
            _userService = userService;
            _jwtHandler = jwtHandler;
            _cache = cache;
        }

        public async Task HandlerAsync(Login command)
        {
            await _userService.LoginAsync(command.Email, command.Password);

            var user = await _userService.GetAsync(command.Email);
            var jwt = _jwtHandler.CreateToken(user.Id, user.Role);
            _cache.SetJwt(command.TokenId, jwt);
        }
    }
}