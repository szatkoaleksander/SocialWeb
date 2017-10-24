using System;

namespace SocialWeb.Infrastructure.Commands.Comment
{
    public class CreateComment : AuthCommandBase
    {
        public string Content { get; set; }
        public Guid PostId { get; set; }
    }
}