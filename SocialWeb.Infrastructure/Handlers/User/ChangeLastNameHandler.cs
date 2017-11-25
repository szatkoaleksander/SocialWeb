using System.Threading.Tasks;
using SocialWeb.Infrastructure.Commands;
using SocialWeb.Infrastructure.Commands.User;
using SocialWeb.Infrastructure.Services;

namespace SocialWeb.Infrastructure.Handlers.User
{
    public class ChangeLastNameHandler : ICommandHandler<ChangeLastName>
    {
        private readonly IUserService _userService;

        public ChangeLastNameHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task HandlerAsync(ChangeLastName command)
        {
            await _userService.ChangeLastNameAsync(command.UserId, command.NewLastName);
        }
    }
}