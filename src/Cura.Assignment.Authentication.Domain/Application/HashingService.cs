using System.Security.Cryptography;
using Cura.Assignment.Authentication.Domain.SeedWork;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace Cura.Assignment.Authentication.Domain.Application
{
    public class HashingService : IHashingService
    {
        private const int SaltSize = 40;
        private const int HashingIterationsCount = 10000;

        public string GetHash(string password, string salt)
        {
            return Convert.ToBase64String(KeyDerivation.Pbkdf2(
                        password: password!,
                        salt: GetBytes(salt),
                        prf: KeyDerivationPrf.HMACSHA256,
                        iterationCount: HashingIterationsCount,
                        numBytesRequested: 256 / 8));
        }

        public string GetSalt(string password)
        {
            var saltBytes = new byte[SaltSize];
            var range = RandomNumberGenerator.Create();
            range.GetBytes(saltBytes);
            return Convert.ToBase64String(saltBytes);
        }

        private byte[] GetBytes(string value)
        {
            var bytes = new byte[value.Length * sizeof(char)];
            Buffer.BlockCopy(value.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }

    }
}
