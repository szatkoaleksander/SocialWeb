using System;

namespace SocialWeb.Infrastructure.Commands.Comment
{
    public class UpdateComment : AuthCommandBase
    {
        public string Content { get; set; }
        public Guid CommentId { get; set; }
    }
}