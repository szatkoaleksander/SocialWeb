using System;

namespace SocialWeb.Infrastructure.Commands.Message
{
    public class CreateMessage : AuthCommandBase
    {
        public string Content { get; set; }
        public Guid ConversationId { get; set; }
    }
}