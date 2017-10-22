using System;
using System.Threading.Tasks;
using AutoMapper;
using SocialWeb.Core.Domain;
using SocialWeb.Core.Repositories;
using SocialWeb.Infrastructure.DTO;

namespace SocialWeb.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserDto> GetAsync(Guid id)
        {
            var user = await _userRepository.GetAsync(id);

            return _mapper.Map<User, UserDto>(user);
        }

        public async Task<UserDto> GetAsync(string email)
        {
            var user = await _userRepository.GetAsync(email);

            return _mapper.Map<User, UserDto>(user);
        }

        public async Task RegisterAsync(string email, string firstName, string lastName, string password)
        {
            var user = await _userRepository.GetAsync(email);

            if(user != null)
            {
                throw new Exception("User is exists");
            }

            var salt = "test_salt";
            user = new User(email, firstName, lastName, password, salt, "user");

            await _userRepository.AddAsync(user);
        }

        public async Task DeleteAsync(Guid id)
        {
            var user = await _userRepository.GetAsync(id);

            await _userRepository.RemoveAsync(user);
        }
    }
}