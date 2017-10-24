using System.Threading.Tasks;
using SocialWeb.Infrastructure.Commands.User;
using SocialWeb.Infrastructure.Services;

namespace SocialWeb.Infrastructure.Handlers.User
{
    public class ChangePasswordHandler : ICommandHandler<ChangePassword>
    {
        private readonly IUserService _userService;

        public ChangePasswordHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task HandlerAsync(ChangePassword command)
        {
            await _userService.ChangePasswordAsync(command.UserId, command.OldPassword, command.NewPassword);
        }
    }
}