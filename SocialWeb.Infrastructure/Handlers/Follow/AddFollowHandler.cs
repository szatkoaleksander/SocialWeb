using System.Threading.Tasks;
using SocialWeb.Infrastructure.Commands.Follow;
using SocialWeb.Infrastructure.Commands.User;
using SocialWeb.Infrastructure.Services;

namespace SocialWeb.Infrastructure.Handlers.Follow
{
    public class AddFollowHandler : ICommandHandler<AddFollow>
    {
        private readonly IFollowService _followService;
        public AddFollowHandler(IFollowService followService)
        {
            _followService = followService;
        }

        public async Task HandlerAsync(AddFollow command)
        {
            await _followService.AddFollowingAsync(command.UserId, command.ToUserId);
        }
    }
}