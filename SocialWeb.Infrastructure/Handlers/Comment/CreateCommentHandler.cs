using System.Threading.Tasks;
using SocialWeb.Infrastructure.Commands.Comment;
using SocialWeb.Infrastructure.Commands.User;
using SocialWeb.Infrastructure.Services;

namespace SocialWeb.Infrastructure.Handlers.Comment
{
    public class CreateCommentHandler : ICommandHandler<CreateComment>
    {
        private readonly ICommentService _commentService;

        public CreateCommentHandler(ICommentService commentService)
        {
            _commentService = commentService;
        }
        
        public async Task HandlerAsync(CreateComment command)
        {
            await _commentService.AddAsync(command.Content, command.UserId, command.PostId);
        }
    }
}