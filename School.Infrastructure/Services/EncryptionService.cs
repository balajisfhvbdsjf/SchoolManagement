using System.Security.Cryptography;
using System.Text;
using School.Application.Interfaces;

namespace School.Infrastructure.Services
{
    public class EncryptionService : IEncryptionService
    {
        public string Encrypt(string input)
        {
            using var sha = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(input);
            var hash = sha.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }
    }
}
