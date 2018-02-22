using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SocialWeb.Core.Domain;
using SocialWeb.Core.Repositories;
using SocialWeb.Infrastructure.EF;

namespace SocialWeb.Infrastructure.Repositories
{
    public class ConversationRepository : IConversationRepository
    {
        private readonly EFContext _context;

        public ConversationRepository(EFContext context)
        {
            _context = context;
        }

        public async Task<Conversation> GetAsync(Guid id)
            => await _context.Conversation.Include(x => x.UserConversations).Include(x => x.Messages)
                .SingleOrDefaultAsync(x => x.Id == id);

        public async Task<IEnumerable<Conversation>> GetAllAsync()
            => await _context.Conversation.Include(x => x.UserConversations).Include(x => x.Messages).ToListAsync();

        public async Task AddAsync(Conversation conversation)
        {
            await _context.Conversation.AddAsync(conversation);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Conversation conversation)
        {
            _context.Conversation.Update(conversation);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(Conversation conversation)
        {
            _context.Conversation.Remove(conversation);
            await _context.SaveChangesAsync();
        }
    }
}
