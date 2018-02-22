using System.Threading.Tasks;
using SocialWeb.Infrastructure.Commands.Conversation;
using SocialWeb.Infrastructure.Commands;
using SocialWeb.Infrastructure.Services;

namespace SocialWeb.Infrastructure.Handlers.Conversation
{
    public class CreateConversationHandler : ICommandHandler<CreateConversation>
    {
        private readonly IConversationService _conversationService;

        public CreateConversationHandler(IConversationService conversationService)
        {
            _conversationService = conversationService;
        }
        
        public async Task HandlerAsync(CreateConversation command)
        {
            await _conversationService.AddConversation(command.UserList);
        }
    }
}