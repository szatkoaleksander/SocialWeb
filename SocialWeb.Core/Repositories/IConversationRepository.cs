using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SocialWeb.Core.Domain;

namespace SocialWeb.Core.Repositories
{
    public interface IConversationRepository : IRepository
    {
        Task<Conversation> GetAsync(Guid id);
        Task<IEnumerable<Conversation>> GetAllAsync();
        Task AddAsync(Conversation conversation);
        Task UpdateAsync(Conversation conversation);
        Task RemoveAsync(Conversation conversation);
    }
}
