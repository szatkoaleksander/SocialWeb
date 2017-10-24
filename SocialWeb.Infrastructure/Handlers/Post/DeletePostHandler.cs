using System.Threading.Tasks;
using SocialWeb.Infrastructure.Commands.Post;
using SocialWeb.Infrastructure.Commands.User;
using SocialWeb.Infrastructure.Services;

namespace SocialWeb.Infrastructure.Handlers.Post
{
    public class DeletePostHandler : ICommandHandler<DeletePost>
    {
        private readonly IPostService _postService;

        public DeletePostHandler(IPostService postService)
        {
            _postService = postService;
        }
        
        public async Task HandlerAsync(DeletePost command)
        {
            await _postService.RemoveAsync(command.UserId, command.PostId);
        }
    }
}