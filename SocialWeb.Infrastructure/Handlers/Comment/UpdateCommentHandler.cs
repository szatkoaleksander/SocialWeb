using System.Threading.Tasks;
using SocialWeb.Infrastructure.Commands.Comment;
using SocialWeb.Infrastructure.Commands.User;
using SocialWeb.Infrastructure.Services;

namespace SocialWeb.Infrastructure.Handlers.Comment
{
    public class UpdateCommentHandler : ICommandHandler<UpdateComment>
    {
        private readonly ICommentService _commentService;

        public UpdateCommentHandler(ICommentService commentService)
        {
            _commentService = commentService;
        }
        
        public async Task HandlerAsync(UpdateComment command)
        {
            await _commentService.UpdateAsync(command.Content, command.CommentId, command.UserId);
        }
    }
}