
using System.Threading.Tasks;

namespace SocialWeb.Infrastructure.Commands.User
{
    public interface ICommandHandler<T> where T : ICommand
    {
         Task HandlerAsync(T command);
    }
}