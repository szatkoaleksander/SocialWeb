using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using SocialWeb.Infrastructure.Commands;
using SocialWeb.Infrastructure.Commands.User;
using SocialWeb.Infrastructure.Extensions;

namespace SocialWeb.API.Controllers
{
    [Route("[Controller]")]
    public class LoginController : ApiControllerBase
    {
        private readonly IMemoryCache _cache;

        public LoginController(ICommandDispatcher commandDispatcher,
            IMemoryCache cache) : base(commandDispatcher)
        {
            _cache = cache;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Login command)
        {
            command.TokenId = Guid.NewGuid();
            await DispatchAsync(command);

            var jwt = _cache.GetJwt(command.TokenId);

            return Json(jwt);
        }
    }
}