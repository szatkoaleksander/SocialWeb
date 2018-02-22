using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SocialWeb.Core.Domain;

namespace SocialWeb.Core.Repositories
{
    public interface IMessageRepository : IRepository
    {
        Task AddMessageAsync(Message message);
    }
}