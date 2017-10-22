using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SocialWeb.Core.Domain;
using SocialWeb.Core.Repositories;

namespace SocialWeb.Infrastructure.Repositories
{
    public class PostRepository : IPostRepository
    {
        private static ISet<Post> _post = new HashSet<Post>();

        public async Task<Post> GetAsync(Guid id)
            => await Task.FromResult(_post.SingleOrDefault(x => x.Id == id));

        public async Task AddAsync(Post post)
        {
            _post.Add(post);
            await Task.CompletedTask;
        }
        
        public Task UpdateAsync(Post post)
        {
            throw new NotImplementedException();
        }

        public async Task RemoveAsync(Post post)
        {
            _post.Remove(post);
            await Task.CompletedTask;
        }
    }
}