using System.Threading.Tasks;
using SocialWeb.Infrastructure.Commands;
using SocialWeb.Infrastructure.Commands.Post;
using SocialWeb.Infrastructure.Services;

namespace SocialWeb.Infrastructure.Handlers.Post
{
    public class UpdatePostHandler : ICommandHandler<UpdatePost>
    {
        private readonly IPostService _postService;
        public UpdatePostHandler(IPostService postService)
        {
            _postService = postService;
        }

        public async Task HandlerAsync(UpdatePost command)
        {
            await _postService.UpdateAsync(command.NewContent, command.UserId, command.PostId);
        }
    }
}