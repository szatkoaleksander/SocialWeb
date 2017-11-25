using System.Threading.Tasks;

namespace SocialWeb.Infrastructure.Commands
{
    public interface ICommandHandler<T> where T : ICommand
    {
         Task HandlerAsync(T command);
    }
}