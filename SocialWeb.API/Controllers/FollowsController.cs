using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialWeb.Infrastructure.Commands;
using SocialWeb.Infrastructure.Commands.Follow;

namespace SocialWeb.API.Controllers
{
    [Route("[controller]")]
    public class FollowsController : ApiControllerBase
    {
        public FollowsController(ICommandDispatcher commandDispatcher) : base(commandDispatcher)
        {
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddFollow([FromBody]AddFollow command)
        {
            await DispatchAsync(command);

            return Ok();
        }
    }
}