using System;

namespace SocialWeb.Infrastructure.DTO
{
    public class CommentDto
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Guid UserId { get; set; }
        public Guid PostId { get; set; }
    }
}