using System;
using System.Threading.Tasks;
using SocialWeb.Core.Domain;

namespace SocialWeb.Core.Repositories
{
    public interface IPostRepository : IRepository
    {
         Task<Post> GetAsync(Guid id);
         Task AddAsync(Post post);
         Task UpdateAsync(Post post);
         Task RemoveAsync(Post post);
    }
}