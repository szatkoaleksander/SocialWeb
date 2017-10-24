using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialWeb.Infrastructure.Commands;
using SocialWeb.Infrastructure.Commands.Comment;

namespace SocialWeb.API.Controllers
{
    [Route("[controller]")]
    public class CommentsController : ApiControllerBase
    {
        public CommentsController(ICommandDispatcher commandDispatcher) : base(commandDispatcher)
        {
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateComment([FromBody]CreateComment command)
        {
            await DispatchAsync(command);

            return Created($"post/comment-comment.Id", null);
        }

        [Authorize]
        [HttpPut]
        public async Task<IActionResult> UpdateComment([FromBody]UpdateComment command)
        {
            await DispatchAsync(command);

            return NoContent();
        }
        
        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> DeleteComment([FromBody]DeleteComment command)
        {
            await DispatchAsync(command);

            return NoContent();
        }
    }
}