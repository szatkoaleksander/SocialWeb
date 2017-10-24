using System;
using System.Collections.Generic;

namespace SocialWeb.Core.Domain
{
    public class User
    {
        public Guid Id { get; protected set; }
        public string Email { get; protected set; }
        public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
        public string Password { get; protected set; }
        public string Salt { get; protected set; }
        public string Role { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }
        public ICollection<Post> Posts { get; protected set; }
        public ICollection<Comment> Comments { get; protected set; }

        public User(string email, string firstName, string LastName,
                    string password, string salt, string role)
        {
            Id = Guid.NewGuid();
            SetEmail(email);
            SetFirstName(firstName);
            SetLastName(LastName);
            SetPassword(password, salt);
            Role = role;
            CreatedAt = DateTime.UtcNow;

            Posts = new List<Post>();
            Comments = new List<Comment>();
        }

        protected User() {}

        public void SetEmail(string email)
        {
            if(string.IsNullOrWhiteSpace(email))
            {
                throw new Exception("Email is invalid");
            }

            Email = email.ToLowerInvariant();
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetFirstName(string firstName)
        {
            if(string.IsNullOrWhiteSpace(firstName))
            {
                throw new Exception("FirstName is invalid");
            }

            FirstName = firstName;
            UpdatedAt = DateTime.UtcNow;
        }
        public void SetLastName(string lastName)
        {
            if(string.IsNullOrWhiteSpace(lastName))
            {
                throw new Exception("LastName is invalid");
            }

            LastName = lastName;
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetPassword(string password, string salt)
        {
            if(string.IsNullOrEmpty(password))
            {
                throw new Exception("Password can not be empty");
            }

            if(string.IsNullOrEmpty(salt))
            {
                throw new Exception("Salt can not be empty");
            }

            if(password.Length < 8)
            {
                throw new Exception("Password is to short");
            }

            if(password.Length > 200)
            {
                throw new Exception("Password is to long");
            }

            Password = password;
            Salt = salt;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}