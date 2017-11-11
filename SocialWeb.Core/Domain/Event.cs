using System;

namespace SocialWeb.Core.Domain
{
    public class Event
    {
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }

        public Event(string name)
        {
            Id = Guid.NewGuid();
            SetName(name);
            CreatedAt = DateTime.UtcNow;
        }

        public void SetName(string name)
        {
            if(string.IsNullOrEmpty(name))
            {
                throw new Exception("Event name can not be null");
            }

            Name = name;
            UpdatedAt = DateTime.UtcNow;
        }

        protected Event() {}
        
    }
}