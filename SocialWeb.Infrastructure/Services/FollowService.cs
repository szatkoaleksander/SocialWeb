using System;
using System.Threading.Tasks;
using SocialWeb.Core.Domain;
using SocialWeb.Core.Repositories;
using System.Linq;

namespace SocialWeb.Infrastructure.Services
{
    public class FollowService : IFollowService
    {
        private readonly IFollowRepository _followRepository;
        private readonly IUserRepository _userRepository;

        public FollowService(IFollowRepository followRepository, IUserRepository userRepository)
        {
            _followRepository = followRepository;
            _userRepository = userRepository;
        }

        public async Task AddFollowingAsync(Guid fromUserId, Guid toUserId)
        {
            var fromUser = await _userRepository.GetAsync(fromUserId); 
            var toUser = await _userRepository.GetAsync(toUserId);

            if(fromUser == null || toUser == null) 
            {
                throw new Exception("You can not follow this user");
            }

            var isFollow = await _followRepository.GetFollowingValidationAsync(fromUser.Id, toUser.Id);

            if(isFollow > 0 )
            {
                throw new Exception("You followed this user");
            }

            var follow = new Follow(fromUser, toUser);

            await _followRepository.AddFollowAsync(follow);
        }
    }
}