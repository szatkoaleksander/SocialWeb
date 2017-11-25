using System;
using System.Collections.Generic;

namespace SocialWeb.Infrastructure.DTO
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; protected set; }
        public ICollection<PostDto> Posts { get; set; }
        public ICollection<CommentDto> Comments { get; set; }
        public ICollection<FollowToDto> Following { get; set; } 
        public ICollection<FollowFromDto> Followers { get; set; }
    }
}