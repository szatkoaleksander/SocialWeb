using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SocialWeb.Core.Domain;

namespace SocialWeb.Core.Repositories
{
    public interface IFollowRepository : IRepository
    {
        Task<IEnumerable<Follow>> GetFollowingAsync(Guid userId);
        Task AddFollowAsync(Follow follow);
    }
}