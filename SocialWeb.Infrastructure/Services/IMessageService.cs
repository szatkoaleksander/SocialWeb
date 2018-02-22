using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SocialWeb.Infrastructure.DTO;

namespace SocialWeb.Infrastructure.Services
{
    public interface IMessageService : IService
    {
        Task<IEnumerable<MessageDto>> GetMessagesAsync();
        Task AddMessageAsync(string content, Guid userId, Guid conversationId);
    }
}