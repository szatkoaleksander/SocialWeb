using System.Threading.Tasks;
using SocialWeb.Infrastructure.Commands.User;

namespace SocialWeb.Infrastructure.Handlers.User
{
    public class AuthHandler : ICommandHandler<AuthCommand>
    {
        public AuthHandler()
        {
        }

        public async Task HandlerAsync(AuthCommand command)
        {
            await Task.CompletedTask;
        }
    }
}