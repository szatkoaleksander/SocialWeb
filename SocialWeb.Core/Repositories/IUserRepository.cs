using System;
using System.Threading.Tasks;
using SocialWeb.Core.Domain;

namespace SocialWeb.Core.Repositories
{
    public interface IUserRepository : IRepository
    {
         Task<User> GetAsync(Guid id);
         Task<User> GetAsync(string email);
         Task AddAsync(User user);
         Task UpdateAsync(User user);
         Task RemoveAsync(User user); 
    }
}