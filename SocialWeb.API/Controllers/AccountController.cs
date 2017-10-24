using SocialWeb.Infrastructure.Commands;

namespace SocialWeb.API.Controllers
{
    public class AccountController : ApiControllerBase
    {
        public AccountController(ICommandDispatcher commandDispatcher) : base(commandDispatcher)
        {
        }
    }
}