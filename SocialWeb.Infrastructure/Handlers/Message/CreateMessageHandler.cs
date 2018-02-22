using System.Threading.Tasks;
using SocialWeb.Infrastructure.Commands;
using SocialWeb.Infrastructure.Commands.Message;
using SocialWeb.Infrastructure.Services;

namespace SocialWeb.Infrastructure.Handlers.Message
{
    public class CreateMessageHandler : ICommandHandler<CreateMessage>
    {
        private readonly IMessageService _messageService;

        public CreateMessageHandler(IMessageService messageService)
        {
            _messageService = messageService;
        }
        
        public async Task HandlerAsync(CreateMessage command)
        {
            await _messageService.AddMessageAsync(command.Content, command.UserId, command.ConversationId);
        }
    }
}