namespace SocialWeb.Infrastructure.Commands.User
{
    public class ChangeFirstName : AuthCommandBase
    {
        public string NewFirstName { get; set; }
    }
}