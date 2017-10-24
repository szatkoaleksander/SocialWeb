using System.Threading.Tasks;
using SocialWeb.Infrastructure.Commands.Comment;
using SocialWeb.Infrastructure.Commands.User;
using SocialWeb.Infrastructure.Services;

namespace SocialWeb.Infrastructure.Handlers.Comment
{
    public class DeleteCommentHandler : ICommandHandler<DeleteComment>
    {
        private readonly ICommentService _commentService;

        public DeleteCommentHandler(ICommentService commentService)
        {
            _commentService = commentService;
        }
        
        public async Task HandlerAsync(DeleteComment command)
        {
            await _commentService.RemoveAsync(command.CommentId, command.UserId);
        }
    }
}