namespace SocialWeb.Infrastructure.Commands.Post
{
    public class CreatePost : AuthCommandBase
    {
        public string Content { get; set; }
    }
}