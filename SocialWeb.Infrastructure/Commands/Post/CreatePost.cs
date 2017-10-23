using System;

namespace SocialWeb.Infrastructure.Commands.Post
{
    public class CreatePost : ICommand
    {
        public string Content { get; set; }
        public Guid UserId { get; set; }
    }
}