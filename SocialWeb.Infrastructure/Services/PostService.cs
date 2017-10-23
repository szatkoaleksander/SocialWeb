using System;
using System.Threading.Tasks;
using AutoMapper;
using SocialWeb.Core.Domain;
using SocialWeb.Core.Repositories;
using SocialWeb.Infrastructure.DTO;

namespace SocialWeb.Infrastructure.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public PostService(IPostRepository postRepository,
             IUserRepository userRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<PostDto> GetAsync(Guid id)
        {
            var post = await _postRepository.GetAsync(id);

            return _mapper.Map<Post, PostDto>(post);
        }

        public async Task AddAsync(string content, Guid userId)
        {
            var user = await _userRepository.GetAsync(userId);
            var post = new Post(content, user);

            await _postRepository.AddAsync(post);
        }

        public async Task RemoveAsync(Guid id)
        {
            var post = await _postRepository.GetAsync(id); 
            await _postRepository.RemoveAsync(post);
        }
    }
}