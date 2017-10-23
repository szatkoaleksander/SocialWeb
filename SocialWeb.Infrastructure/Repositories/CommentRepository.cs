using System.Collections.Generic;
using System.Threading.Tasks;
using SocialWeb.Core.Domain;
using SocialWeb.Core.Repositories;

namespace SocialWeb.Infrastructure.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private static ISet<Comment> _comment = new HashSet<Comment>();

        public async Task AddAsync(Comment comment)
        {
            _comment.Add(comment);
            await Task.CompletedTask;
        }

        public Task UpdateAsync(Comment comment)
        {
            throw new System.NotImplementedException();
        }

        public async Task RemoveAsync(Comment comment)
        {
            _comment.Remove(comment);
            await Task.CompletedTask;
        }
    }
}