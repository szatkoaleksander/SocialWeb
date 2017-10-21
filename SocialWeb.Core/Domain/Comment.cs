using System;

namespace SocialWeb.Core.Domain
{
    public class Comment
    {
        public Guid Id { get; protected set; }
        public string Content { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }
        public Guid PostId { get; protected set; }
        public Post Post { get; protected set; }

        public Comment(string content, Post post)
        {
            SetContent(content);
            CreatedAt = DateTime.UtcNow;

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

            if(content.Length > 5000)
            {
                throw new Exception("Content is to long");
            }

            Content = content;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}