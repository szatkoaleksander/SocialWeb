using System;
using System.Threading.Tasks;
using AutoMapper;
using SocialWeb.Core.Domain;
using SocialWeb.Core.Repositories;

namespace SocialWeb.Infrastructure.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IPostRepository _postRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public CommentService(ICommentRepository commentRepository, IPostRepository postRepository,
             IUserRepository userRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _postRepository = postRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task AddAsync(string content, Guid userId, Guid postId)
        {
            var user = await _userRepository.GetAsync(userId);
            var post = await _postRepository.GetAsync(postId);

            var comment = new Comment(content, user, post);

            await _commentRepository.AddAsync(comment); 
        }

        public async Task UpdateAsync(string content, Guid commentId, Guid userId)
        {
            var comment = await _commentRepository.GetAsync(commentId);

            if(comment.UserId != userId)
            {
                throw new Exception("You can update comment");
            }

            comment.SetContent(content);

            await _commentRepository.UpdateAsync(comment);
        }

        public async Task RemoveAsync(Guid commentId, Guid userId)
        {
            var comment = await _commentRepository.GetAsync(commentId);

            if(comment.UserId != userId)
            {
                throw new Exception("You can remove comment");
            }

            await _commentRepository.RemoveAsync(comment);
        }
    }
}