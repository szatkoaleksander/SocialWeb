using System;
using System.Collections.Generic;
using System.Text;
using SocialWeb.Core.Domain;

namespace SocialWeb.Infrastructure.DTO
{
    public class ConversationDto
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public ICollection<MessageDto> Messages { get; set; }
    }
}
