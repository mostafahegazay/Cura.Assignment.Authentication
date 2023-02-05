namespace Cura.Assignment.Authentication.Domain.SeedWork
{
    public interface IHashingService
    {
        string GetSalt(string password);
        string GetHash(string password, string salt);
    }
}
