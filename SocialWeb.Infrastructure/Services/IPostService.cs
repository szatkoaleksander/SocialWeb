using System;
using System.Threading.Tasks;
using SocialWeb.Infrastructure.DTO;

namespace SocialWeb.Infrastructure.Services
{
    public interface IPostService
    {
        Task<PostDto> GetAsync(Guid id);
        Task AddAsync(string content, Guid userId);
        Task RemoveAsync(Guid id);
    }
}