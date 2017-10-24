using System;

namespace SocialWeb.Infrastructure.Commands.Post
{
    public class UpdatePost : AuthCommandBase
    {
        public Guid PostId { get; set; }
        public string NewContent { get; set; }
    }
}