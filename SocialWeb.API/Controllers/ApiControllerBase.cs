using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SocialWeb.Infrastructure.Commands;

namespace SocialWeb.API.Controllers
{
    public class ApiControllerBase : Controller
    {
        private readonly ICommandDispatcher _commandDispatcher;

       protected Guid UserId => User?.Identity?.IsAuthenticated == true ?
            Guid.Parse(User.Identity.Name) :
            Guid.Empty;

        protected ApiControllerBase(ICommandDispatcher commandDispatcher)
        {
            _commandDispatcher = commandDispatcher;
        }

        protected async Task DispatchAsync<T>(T command) where T : ICommand
        {
            if(command is IAuthCommand authCommand)
            {
                authCommand.UserId = UserId;
            }

            await _commandDispatcher.DispatchAsync(command);
        }
    }
}