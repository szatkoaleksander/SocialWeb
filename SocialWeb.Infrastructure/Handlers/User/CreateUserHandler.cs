using System.Threading.Tasks;
using SocialWeb.Infrastructure.Commands;
using SocialWeb.Infrastructure.Commands.User;
using SocialWeb.Infrastructure.Services;

namespace SocialWeb.Infrastructure.Handlers.User
{
    public class CreateUserHandler : ICommandHandler<CreateUser>
    {
        private readonly IUserService _userService;

        public CreateUserHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task HandlerAsync(CreateUser command)
        {
            await _userService.RegisterAsync(command.Email, command.FirstName, command.LastName, command.Password);
        }
    }
}