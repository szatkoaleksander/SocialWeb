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
    public class PostRepository : IPostRepository, ISqlRepository
    {
        private readonly EFContext _context;

        public PostRepository(EFContext context)
        {
            _context = context;
        }        
        
        public async Task<Post> GetAsync(Guid id)
            => await _context.Post.Include(x => x.Comments).SingleOrDefaultAsync(x => x.Id == id);

        public async Task<IEnumerable<Post>> GetUserPostAsync(Guid userId)
            => await _context.Post.Include(x => x.Comments).Where(x => x.UserId == userId).OrderByDescending(x => x.UpdatedAt).ToListAsync();

        public async Task AddAsync(Post post)
        {
            await _context.Post.AddAsync(post);
            await _context.SaveChangesAsync();
        }
        
        public async Task UpdateAsync(Post post)
        {
            _context.Post.Update(post);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(Post post)
        {
            _context.Post.Remove(post);
            await _context.SaveChangesAsync();
        }
    }
}