using System;
using System.Threading.Tasks;
using SocialWeb.Infrastructure.DTO;

namespace SocialWeb.Infrastructure.Services
{
    public interface IUserService : IService
    {
        Task<UserDto> GetAsync(Guid id);
        Task<UserDto> GetAsync(string email);
        Task RegisterAsync(string email, string firstName, string lastName, string password);
        Task DeleteAsync(Guid id);
    }
}