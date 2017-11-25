using System;
using System.Collections.Generic;
using System.Text;

namespace SocialWeb.Core.Domain
{
    public class Conversation
    {
        public Guid Id { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public ICollection<UserConversation> UserConversations { get; protected set; }
        public ICollection<Message> Messages { get; protected set; }

        public Conversation(List<UserConversation> userConversations, List<Message> messages)
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.UtcNow;;

            UserConversations = userConversations;
            Messages = messages;
        }

        protected Conversation() { }
    }
}
