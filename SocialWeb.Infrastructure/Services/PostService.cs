using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using System.Linq;
using SocialWeb.Core.Domain;
using SocialWeb.Core.Repositories;
using SocialWeb.Infrastructure.DTO;

namespace SocialWeb.Infrastructure.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly IUserRepository _userRepository;
        private readonly IFollowRepository _followRepository;
        private readonly IMapper _mapper;

        public PostService(IPostRepository postRepository,
             IUserRepository userRepository, IMapper mapper, IFollowRepository followRepository)
        {
            _postRepository = postRepository;
            _userRepository = userRepository;
            _followRepository = followRepository;
            _mapper = mapper;
        }

        public async Task<PostDto> GetAsync(Guid id)
        {
            var post = await _postRepository.GetAsync(id);

            return _mapper.Map<Post, PostDto>(post);
        }

        public async Task<IEnumerable<PostDto>> GetMainPostAsync(Guid userId)
        {
            
            var post = await _postRepository.GetUserPostAsync(userId);
            var following = await _followRepository.GetFollowingAsync(userId);

            List<Post> posts = new List<Post>();
            posts.AddRange(post);

            foreach(var i in following)
            {
                post = await _postRepository.GetUserPostAsync(i.ToUserId);
                posts.AddRange(post); 
            }

            posts.OrderBy(x => x.CreatedAt);

            return _mapper.Map<IEnumerable<Post>, IEnumerable<PostDto>>(posts);
        }

        public async Task<IEnumerable<PostDto>> GetUserPostAsync(Guid userId)
        {    
            var posts = await _postRepository.GetUserPostAsync(userId);
            posts.OrderBy(x => x.CreatedAt);

            return _mapper.Map<IEnumerable<Post>, IEnumerable<PostDto>>(posts);
        }

        public async Task AddAsync(string content, Guid userId)
        {
            var user = await _userRepository.GetAsync(userId);
            var post = new Post(content, user);

            await _postRepository.AddAsync(post);
        }

        public async Task UpdateAsync(string content, Guid userId, Guid postId)
        {
            var post = await _postRepository.GetAsync(postId);

            if(post.UserId != userId)
            {
                throw new Exception("You can not update post");
            }

            post.SetContent(content);
            await _postRepository.UpdateAsync(post);
        }

        public async Task RemoveAsync(Guid userId, Guid postId)
        {
            var post = await _postRepository.GetAsync(postId);

            if(post.UserId != userId)
            {
                throw new Exception("You can not delete post");
            }
            
            await _postRepository.RemoveAsync(post);
        }
    }
}