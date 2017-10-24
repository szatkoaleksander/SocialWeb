namespace SocialWeb.Infrastructure.Commands.User
{
    public class ChangeLastName : AuthCommandBase
    {
        public string NewLastName { get; set; }
    }
}