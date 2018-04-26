using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialWeb.Infrastructure.Commands;
using SocialWeb.Infrastructure.Commands.User;
using SocialWeb.Infrastructure.Services;

namespace SocialWeb.API.Controllers
{
    [Route("[Controller]")]
    public class PostsWallController : ApiControllerBase
    {
        private readonly IPostService _postService;
        private readonly IFollowService _followService;

        public PostsWallController(ICommandDispatcher commandDispatcher, IPostService postService, IFollowService followService)
            : base(commandDispatcher)
        {
            _postService = postService;
            _followService = followService;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetMainPostWall()
        {
            await DispatchAsync(new AuthCommand());

            var posts = await _postService.GetMainPostAsync(UserId);

            return Ok(posts);
        }

        [Authorize]
        [HttpGet]
        [Route("users")]
        public async Task<IActionResult> GetUserPostWall()
        {
            await DispatchAsync(new AuthCommand());

            var posts = await _postService.GetUserPostAsync(UserId);

            return Ok(posts);
        }
 
    }
}