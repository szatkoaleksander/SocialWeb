using System.Threading.Tasks;
using SocialWeb.Infrastructure.Commands.User;
using SocialWeb.Infrastructure.Services;

namespace SocialWeb.Infrastructure.Handlers.User
{
    public class ChangeFirstNameHandler : ICommandHandler<ChangeFirstName>
    {
        private readonly IUserService _userService;

        public ChangeFirstNameHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task HandlerAsync(ChangeFirstName command)
        {
            await _userService.ChangeFirstNameAsync(command.UserId, command.NewFirstName);
        }
    }
}