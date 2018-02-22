using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SocialWeb.Infrastructure.DTO;

namespace SocialWeb.Infrastructure.Services
{
    public interface IConversationService : IService
    {
        Task<ConversationDto> GetAsync(Guid id);
        Task<IEnumerable<ConversationDto>> GetAllAsync();
        Task AddConversation(List<Guid> userId);
    }
}
