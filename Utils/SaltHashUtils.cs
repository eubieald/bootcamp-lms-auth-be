using System.Security.Cryptography;

namespace lms_auth_be.Utils
{
    public class SaltHashUtils
    {
        private const int SaltSize = 16;      // 128-bit salt
        private const int KeySize = 32;       // 256-bit derived key
        private const int Iterations = 10000; // PBKDF2 iterations
    public (byte[] Hash, byte[] Salt) HashPassword(string password)
        {
            // salting
            byte[] salt = new byte[SaltSize];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            using var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations, HashAlgorithmName.SHA256);
            byte[] hash = pbkdf2.GetBytes(KeySize);

            return (hash, salt);
        }

        public bool VerifyPassword(string password, byte[] hash, byte[] salt)
        {

            using var pbkdf2 = new Rfc2898DeriveBytes(password, salt, Iterations, HashAlgorithmName.SHA256);
            byte[] actualHashBytes = pbkdf2.GetBytes(KeySize);

            return CryptographicOperations.FixedTimeEquals(hash, actualHashBytes);
        }
    }
}
