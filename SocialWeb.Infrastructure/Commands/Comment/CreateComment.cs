using System;

namespace SocialWeb.Infrastructure.Commands.Comment
{
    public class CreateComment : ICommand
    {
        public string Content { get; set; }
        public Guid UserId { get; set; }
        public Guid PostId { get; set; }
    }
}