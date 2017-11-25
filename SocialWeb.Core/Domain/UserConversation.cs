using System;

namespace SocialWeb.Core.Domain
{
    public class UserConversation
    {
        public Guid UserId { get; protected set; }
        public User User { get; protected set; }
        public Guid ConversationId { get; protected set; }
        public Conversation Conversation { get; protected set; }
    }
}
