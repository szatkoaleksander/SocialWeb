using System.Collections.Generic;
using System.Threading.Tasks;
using SocialWeb.Core.Domain;
using SocialWeb.Core.Repositories;
using SocialWeb.Infrastructure.EF;

namespace SocialWeb.Infrastructure.Repositories
{
    public class CommentRepository : ICommentRepository, ISqlRepository
    {
        private readonly EFContext _context;

        public CommentRepository(EFContext context)
        {
            _context = context;
        } 

        public async Task AddAsync(Comment comment)
        {
            await _context.Comment.AddAsync(comment);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Comment comment)
        {
            _context.Comment.Update(comment);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(Comment comment)
        {
            _context.Comment.Remove(comment);
            await _context.SaveChangesAsync();
        }
    }
}