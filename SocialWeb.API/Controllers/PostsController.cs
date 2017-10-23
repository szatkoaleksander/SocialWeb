using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SocialWeb.Infrastructure.Commands;
using SocialWeb.Infrastructure.Commands.Post;
using SocialWeb.Infrastructure.Services;

namespace SocialWeb.API.Controllers
{
    [Route("[controller]")]
    public class PostsController : ApiControllerBase
    {
        private readonly IPostService _postService;
        
        public PostsController(IPostService postService, ICommandDispatcher commandDispatcher) : base(commandDispatcher)
        {
            _postService = postService;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var post = await _postService.GetAsync(id);

            if(post == null)
            {
                NoContent();
            }

            return Ok(post);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePost([FromBody]CreatePost command)
        {
            await DispatchAsync(command);
           
            return Created($"post/post.Id", null);
        }
    }
}