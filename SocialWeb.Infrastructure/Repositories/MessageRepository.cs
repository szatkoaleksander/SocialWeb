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
    public class MessageRepository : IMessageRepository
    {
        private readonly EFContext _context;

        public MessageRepository(EFContext context)
        {
            _context = context;
        }

        public async Task AddMessageAsync(Message message)
        {
            await _context.Message.AddAsync(message);
            await _context.SaveChangesAsync();
        }
    }
}
