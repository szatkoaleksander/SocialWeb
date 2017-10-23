using System;
using System.Threading.Tasks;

namespace SocialWeb.Infrastructure.Services
{
    public interface ICommentService : IService
    {
         Task AddAsync(string content, Guid userId, Guid postId);
    }
}