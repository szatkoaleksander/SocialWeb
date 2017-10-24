using System;

namespace SocialWeb.Infrastructure.Commands.Post
{
    public class DeletePost : AuthCommandBase
    {
        public Guid PostId { get; set; }
    }
}