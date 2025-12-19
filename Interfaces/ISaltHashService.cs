namespace lms_auth_be.Interfaces
{
    public interface ISaltHashService
    {
        (byte[] Hash, byte[] Salt) HashPassword(string password);
        bool VerifyPassword(string password, byte[] hash, byte[] salt);
    }
}