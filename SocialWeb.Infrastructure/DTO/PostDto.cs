using System;
using System.Collections.Generic;

namespace SocialWeb.Infrastructure.DTO
{
    public class PostDto
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Guid UserId { get; set; }
        public ICollection<CommentDto> Comments { get; set; }
    }
}