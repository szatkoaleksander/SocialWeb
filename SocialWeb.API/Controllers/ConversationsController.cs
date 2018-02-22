using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialWeb.Infrastructure.Commands;
using SocialWeb.Infrastructure.Commands.Conversation;
using SocialWeb.Infrastructure.Commands.Message;
using SocialWeb.Infrastructure.Services;

namespace SocialWeb.API.Controllers
{
    [Route("[controller]")]
    public class ConversationsController : ApiControllerBase
    {
        private readonly IConversationService _conversationService;
        public ConversationsController(ICommandDispatcher commandDispatcher,
             IConversationService conversationService) : base(commandDispatcher)
        {
            _conversationService = conversationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var conversations = await _conversationService.GetAllAsync();

            return Ok(conversations);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddConversation([FromBody]CreateConversation command)
        {
            await DispatchAsync(command);

            return Ok();
        }
        
        [Authorize]
        [HttpPost]
        [Route("conversations")]
        public async Task<IActionResult> AddMessage([FromBody]CreateMessage command)
        {
            await DispatchAsync(command);

            return Ok();
        }
    }
}