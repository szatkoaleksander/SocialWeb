using System;

namespace SocialWeb.Infrastructure.Commands
{
    public interface IAuthCommand : ICommand
    {
        Guid UserId { get; set; }
    }
}