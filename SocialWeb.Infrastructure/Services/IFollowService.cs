using System;
using System.Threading.Tasks;

namespace SocialWeb.Infrastructure.Services
{
    public interface IFollowService : IService
    {
        Task AddFollowingAsync(Guid fromUserId, Guid toUserId);
    }
}