using System.Threading.Tasks;
using SocialWeb.Infrastructure.Commands;
using SocialWeb.Infrastructure.Commands.Post;
using SocialWeb.Infrastructure.Services;

namespace SocialWeb.Infrastructure.Handlers.Post
{
    public class CreatePostHandler : ICommandHandler<CreatePost>
    {
        private readonly IPostService _postService;

        public CreatePostHandler(IPostService postService)
        {
            _postService = postService;
        }
        public async Task HandlerAsync(CreatePost command)
        {
            await _postService.AddAsync(command.Content, command.UserId);
        }
    }
}