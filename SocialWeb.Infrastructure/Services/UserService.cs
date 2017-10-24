using System;
using System.Threading.Tasks;
using AutoMapper;
using SocialWeb.Core.Domain;
using SocialWeb.Core.Repositories;
using SocialWeb.Infrastructure.DTO;
using SocialWeb.Infrastructure.Services.Jwt;

namespace SocialWeb.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IEncrypter _encrypter;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IEncrypter encrypter, IMapper mapper)
        {
            _userRepository = userRepository;
            _encrypter = encrypter;
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
        
        public async Task LoginAsync(string email, string password)
        {
            var user = await _userRepository.GetAsync(email);

            if(user == null)
            {
                throw new Exception("Invalid credentialssXDXDXDX");
            }

            var salt = _encrypter.GetSalt(password);
            var hash = _encrypter.GetHash(password, user.Salt);

            if(hash == null)
            {
                throw new Exception("Invalid credentials");
            }

            if(user.Password == hash)
            {
                return;
            }

            throw new Exception("Invalid credentials");
        }

        public async Task RegisterAsync(string email, string firstName, string lastName, string password)
        {
            var user = await _userRepository.GetAsync(email);

            if(user != null)
            {
                throw new Exception("User is exists");
            }

            var salt = _encrypter.GetSalt(password);
            var hash = _encrypter.GetHash(password, salt);
            user = new User(email, firstName, lastName, hash, salt, "user");

            await _userRepository.AddAsync(user);
        }

        public async Task ChangePasswordAsync(Guid id, string oldPassword, string newPassword)
        {
            var user = await _userRepository.GetAsync(id);

            var salt = _encrypter.GetSalt(oldPassword);
            var hash = _encrypter.GetHash(oldPassword, user.Salt);
            
            if(hash == null)
            {
                throw new Exception("Invalid credentials");
            }

            if(user.Password == hash)
            {
                salt = _encrypter.GetSalt(newPassword);
                hash = _encrypter.GetHash(newPassword, salt);
                
                user.SetPassword(hash, salt);

                await _userRepository.UpdateAsync(user);

                return;
            }

            throw new Exception("Invalid credentials");
        }

        public async Task ChangeFirstNameAsync(Guid id, string newFirstName)
        {
            var user = await _userRepository.GetAsync(id);

            user.SetFirstName(newFirstName);

            await _userRepository.UpdateAsync(user);
        }

        public async Task ChangeLastNameAsync(Guid id, string newLastName)
        {
            var user = await _userRepository.GetAsync(id);

            user.SetLastName(newLastName);

            await _userRepository.UpdateAsync(user);
        }

        public async Task RemoveAsync(Guid id)
        {
            var user = await _userRepository.GetAsync(id);

            await _userRepository.RemoveAsync(user);
        }
    }
}