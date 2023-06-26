using Encore.Domain.Interfaces.CrossCutting;
using System.Security.Cryptography;
using System.Text;

namespace Encore.Infra.CrossCutting.Services
{
    public class PasswordHashService : IPasswordHashService
    {
        public string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                var hash = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
                return hash;
            }
        }

        public bool VerifyPassword(string enteredPassword, string storedPasswordHash)
        {
            using (var sha256 = SHA256.Create())
            {
                var enteredPasswordHashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(enteredPassword));
                var enteredPasswordHash = BitConverter.ToString(enteredPasswordHashedBytes).Replace("-", "").ToLower();

                return enteredPasswordHash == storedPasswordHash;
            }
        }
    }
}
