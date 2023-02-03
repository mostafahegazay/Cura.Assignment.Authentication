
namespace Cura.Assignment.Authentication.Domain.Application
{
    public interface IHashingService
    {
        string GetSalt(string password);
        string GetHash(string password, string salt);
    }
}
