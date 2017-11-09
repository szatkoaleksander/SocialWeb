using System;
using System.Collections.Generic;

namespace SocialWeb.Core.Domain
{
    public class Post
    {
        public Guid Id { get; protected set; }
        public string Content { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }
        public Guid UserId { get; protected set; }
        public User User { get; protected set; }
        public ICollection<Comment> Comments { get; protected set; }

        public Post(string content, User user)
        {
            SetContent(content);
            CreatedAt = DateTime.UtcNow;

            UserId = user.Id;
            User = user;
            Comments = new List<Comment>();
        }

        protected Post() {}

        public void SetContent(string content)
        {
            if(string.IsNullOrEmpty(content))
            {
                throw new Exception("Content can not be empty");
            }

            if(content.Length > 4000)
            {
                throw new Exception("Content is to long");
            }
            
            Content = content;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}