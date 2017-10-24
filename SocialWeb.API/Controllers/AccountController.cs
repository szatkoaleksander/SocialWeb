using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialWeb.Infrastructure.Commands;
using SocialWeb.Infrastructure.Commands.User;
using SocialWeb.Infrastructure.Services;

namespace SocialWeb.API.Controllers
{
    [Route("[Controller]")]
    public class AccountController : ApiControllerBase
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService,
            ICommandDispatcher commandDispatcher) : base(commandDispatcher)
        {
            _userService = userService;
        }

        [Authorize]
        [HttpPut]
        [Route("password")]
        public async Task<IActionResult> ChangePassword([FromBody]ChangePassword command)
        {
            await DispatchAsync(command);

            return NoContent();
        }
        
        [Authorize]
        [HttpPut]
        [Route("firstname")]
        public async Task<IActionResult> ChangeFirstName([FromBody]ChangeFirstName command)
        {
            await DispatchAsync(command);

            return NoContent();
        }
        
        [Authorize]
        [HttpPut]
        [Route("lastname")]
        public async Task<IActionResult> ChangeLastName([FromBody]ChangeLastName command)
        {
            await DispatchAsync(command);

            return NoContent();
        }

        [Authorize]
        [HttpDelete("me")]
        public async Task<IActionResult> Delete()
        {
            await DispatchAsync(new DeleteUser());

            return NoContent();
        }
    }
}