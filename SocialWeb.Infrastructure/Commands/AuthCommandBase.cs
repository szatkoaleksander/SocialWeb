using System;

namespace SocialWeb.Infrastructure.Commands
{
    public class AuthCommandBase : IAuthCommand
    {
        public Guid UserId { get; set; }
    }
}