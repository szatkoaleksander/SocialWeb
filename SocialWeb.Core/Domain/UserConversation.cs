using System;

namespace SocialWeb.Core.Domain
{
    public class UserConversation
    {
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid ConversationId { get; set; }
        public Conversation Conversation { get; set; }
    }
}
