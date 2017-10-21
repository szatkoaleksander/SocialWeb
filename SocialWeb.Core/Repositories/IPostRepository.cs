using System;
using System.Threading.Tasks;
using SocialWeb.Core.Domain;

namespace SocialWeb.Core.Repositories
{
    public interface IPostRepository
    {
         Task<Post> GetAsync(Guid id);
         Task AddAsync(Post post);
         Task UpdateAsync(Post post);
         Task DeleteAsync(Post post);
    }
}