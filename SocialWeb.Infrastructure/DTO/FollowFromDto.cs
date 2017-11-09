using System;

namespace SocialWeb.Infrastructure.DTO
{
    public class FollowFromDto
    {
        public Guid Id { get; set; }
        public Guid FromUserId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}