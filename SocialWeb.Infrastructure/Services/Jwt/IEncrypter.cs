namespace SocialWeb.Infrastructure.Services.Jwt
{
    public interface IEncrypter
    {
        string GetSalt(string value);
        string GetHash(string value, string salt);
    }
}