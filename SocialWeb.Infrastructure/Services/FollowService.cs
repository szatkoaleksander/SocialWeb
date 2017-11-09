using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using SocialWeb.Core.Domain;
using SocialWeb.Core.Repositories;
using SocialWeb.Infrastructure.DTO;

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

            var follow = new Follow(fromUser, toUser);

            await _followRepository.AddFollowAsync(follow);
        }
    }
}