using System;

namespace SocialWeb.Core.Domain
{
    public class Follow
    {
        public Guid Id { get; protected set; }
        public Guid FromUserId { get; protected set; }
        public User FromUser { get; protected set; }
        public Guid ToUserId { get; protected set; }
        public User ToUser { get; protected set; }
        public DateTime CreatedAt { get; protected set; }

        public Follow(User fromUser, User toUser)
        {
            Id = Guid.NewGuid();
            
            FromUserId = fromUser.Id;
            FromUser = fromUser;

            ToUserId = toUser.Id;
            ToUser = toUser;

            CreatedAt = DateTime.UtcNow;
        }

        protected Follow() {}
    }
}