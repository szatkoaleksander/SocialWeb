using System;
using System.Collections.Generic;

namespace SocialWeb.Infrastructure.Commands.Conversation
{
    public class CreateConversation : AuthCommandBase
    {
        public List<Guid> UserList { get; set; }
    }
}