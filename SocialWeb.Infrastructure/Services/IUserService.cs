using System;
using System.Threading.Tasks;
using SocialWeb.Infrastructure.DTO;

namespace SocialWeb.Infrastructure.Services
{
    public interface IUserService : IService
    {
        Task<UserDto> GetAsync(Guid id);
        Task<UserDto> GetAsync(string email);
        Task LoginAsync(string email, string password);
        Task RegisterAsync(string email, string firstName, string lastName, string password);
        Task ChangePasswordAsync(Guid id, string oldPassword, string newPassword);
        Task ChangeFirstNameAsync(Guid id, string newFirstName);
        Task ChangeLastNameAsync(Guid id, string newLastName);
        Task DeleteAsync(Guid id);
    }
}