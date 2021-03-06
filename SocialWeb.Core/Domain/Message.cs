﻿using System;

namespace SocialWeb.Core.Domain
{
    public class Message
    {
        public Guid Id { get; protected set; }
        public string Content { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public Guid UserId { get; protected set; } 
        public User User { get; protected set; }
        public Guid ConversationId { get; protected set; }
        public Conversation Conversation { get; protected set; }

        public Message(string content, User user, Conversation conversation)
        {
            Id = Guid.NewGuid();
            Content = content;
            CreatedAt = DateTime.UtcNow;

            UserId = user.Id;
            User = user;

            ConversationId = conversation.Id;
            Conversation = conversation;
        }

        protected Message() { }
    }
}
