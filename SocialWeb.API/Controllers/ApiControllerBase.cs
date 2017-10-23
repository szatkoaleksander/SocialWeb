using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SocialWeb.Infrastructure.Commands;

namespace SocialWeb.API.Controllers
{
    [Route("[controller]")]
    public class ApiControllerBase : Controller
    {
        private readonly ICommandDispatcher _commandDispatcher;

        protected ApiControllerBase(ICommandDispatcher commandDispatcher)
        {
            _commandDispatcher = commandDispatcher;
        }

        protected async Task DispatchAsync<T>(T command) where T : ICommand
        {
            await _commandDispatcher.DispatchAsync(command);
        }
    }
}