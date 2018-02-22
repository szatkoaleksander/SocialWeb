using System;
using System.Collections.Generic;

namespace SocialWeb.Core.Domain
{
    public class Conversation
    {
        public Guid Id { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public ICollection<UserConversation> UserConversations { get; protected set; }
        public ICollection<Message> Messages { get; protected set; }

        public Conversation()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.UtcNow;;

            UserConversations = new List<UserConversation>();
            Messages = new List<Message>();
        }
    }
}
