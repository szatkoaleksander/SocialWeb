using System;

namespace SocialWeb.Infrastructure.Commands.Follow
{
    public class AddFollow : AuthCommandBase
    {
        public Guid ToUserId { get; set; }
    }
}