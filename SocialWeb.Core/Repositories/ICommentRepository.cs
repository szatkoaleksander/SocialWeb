using System;
using System.Threading.Tasks;
using SocialWeb.Core.Domain;

namespace SocialWeb.Core.Repositories
{
    public interface ICommentRepository : IRepository
    {
         //Task<Comment> GetUserCommentsAsync(Guid id);
         //Task<Comment> GetPostCommentsAsync(Guid id);
         Task AddAsync(Comment comment);
         Task UpdateAsync(Comment comment);
         Task RemoveAsync(Comment comment);
    }
}