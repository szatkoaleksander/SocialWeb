namespace SocialWeb.Infrastructure.Commands.User
{
    public class ChangePassword : AuthCommandBase
    {
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}