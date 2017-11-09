using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SocialWeb.Infrastructure.DTO;

namespace SocialWeb.Infrastructure.Services
{
    public interface IPostService : IService
    {
        Task<PostDto> GetAsync(Guid id);
        Task<IEnumerable<PostDto>> GetMainPostAsync(Guid userId);
        Task<IEnumerable<PostDto>> GetUserPostAsync(Guid userId);
        Task AddAsync(string content, Guid userId);
        Task UpdateAsync(string content, Guid userId, Guid postId);
        Task RemoveAsync(Guid userId, Guid postId);
    }
}