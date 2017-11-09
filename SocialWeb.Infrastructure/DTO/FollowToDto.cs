using System;

namespace SocialWeb.Infrastructure.DTO
{
    public class FollowToDto
    {
        public Guid Id { get; set; }
        public Guid ToUserId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}