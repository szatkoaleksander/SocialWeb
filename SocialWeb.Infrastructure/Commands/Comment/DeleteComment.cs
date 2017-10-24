using System;

namespace SocialWeb.Infrastructure.Commands.Comment
{
    public class DeleteComment : AuthCommandBase
    {
        public Guid CommentId { get; set; }
    }
}