using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SocialWeb.Core.Domain;
using SocialWeb.Core.Repositories;
using SocialWeb.Infrastructure.DTO;

namespace SocialWeb.Infrastructure.Services
{
    public class ConversationService : IConversationService
    {
        private readonly IConversationRepository _conversationRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public ConversationService(IConversationRepository conversationRepository,
            IUserRepository userRepository, IMapper mapper)
        {
            _conversationRepository = conversationRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public Task<ConversationDto> GetAsync(Guid id)
        {                                                                                                                                                                                                                                                                   
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ConversationDto>> GetAllAsync()
        {    
            var conv = await _conversationRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<Conversation>, IEnumerable<ConversationDto>>(conv);
        }

        public async Task AddConversation(List<Guid> userId)
        {
            var conversation = new Conversation();

            foreach(var i in userId)
            {
                
                var user = await _userRepository.GetAsync(i);
                var uc = new UserConversation();

                uc.User = user;
                uc.UserId= user.Id;

                uc.Conversation = conversation;
                uc.ConversationId = conversation.Id;

                conversation.UserConversations.Add(uc);
                //user.UserConversations.
              
            }

            await _conversationRepository.AddAsync(conversation);
        }
    }
}
