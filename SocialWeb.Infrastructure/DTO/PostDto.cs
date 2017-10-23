using System;
using System.Collections.Generic;
using SocialWeb.Core.Domain;

namespace SocialWeb.Infrastructure.DTO
{
    public class PostDto
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Guid UserId { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}