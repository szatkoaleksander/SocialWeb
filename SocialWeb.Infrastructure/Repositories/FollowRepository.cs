using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SocialWeb.Core.Domain;
using SocialWeb.Core.Repositories;
using SocialWeb.Infrastructure.EF;

namespace SocialWeb.Infrastructure.Repositories
{
    public class FollowRepository : IFollowRepository, ISqlRepository
    {
        private readonly EFContext _context;

        public FollowRepository(EFContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Follow>> GetFollowingAsync(Guid userId)
            => await _context.Follow.Where(x => x.FromUserId == userId).ToListAsync();

        public async Task AddFollowAsync(Follow follow)
        {
            await _context.Follow.AddAsync(follow);
            await _context.SaveChangesAsync();
        }
    }
}