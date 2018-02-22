using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SocialWeb.Core.Domain;
using SocialWeb.Core.Repositories;
using SocialWeb.Infrastructure.DTO;

namespace SocialWeb.Infrastructure.Services
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IUserRepository _userRepository;
        private readonly IConversationRepository _conversationRepository;

        public MessageService(IMessageRepository messageRepository, IUserRepository userRepository,
            IConversationRepository conversationRepository)
        {
            _messageRepository = messageRepository;
            _userRepository = userRepository;
            _conversationRepository = conversationRepository;
        }

        public Task<IEnumerable<MessageDto>> GetMessagesAsync()
        {
            throw new NotImplementedException();
        }

        public async Task AddMessageAsync(string content, Guid userId, Guid conversationId)
        {
            var user = await _userRepository.GetAsync(userId);
            var conversation = await _conversationRepository.GetAsync(conversationId);

            var message = new Message(content, user, conversation);


            await _messageRepository.AddMessageAsync(message);
        }
    }
}