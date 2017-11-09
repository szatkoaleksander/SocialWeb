using System;

namespace SocialWeb.Core.Domain
{
    public class Comment
    {
        public Guid Id { get; protected set; }
        public string Content { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }
        public Guid UserId { get; protected set; }
        public User User { get; protected set; }
        public Guid PostId { get; protected set; }
        public Post Post { get; protected set; }

        public Comment(string content, User user, Post post)
        {
            SetContent(content);
            CreatedAt = DateTime.UtcNow;

            UserId = user.Id;
            User = user;
            PostId = post.Id;
            Post = post;
        }

        protected Comment() {}

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