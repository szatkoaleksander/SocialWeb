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
    }
}