namespace TestProject.Common.Utility
{
    public class PasswordHasher
    {
        public static (Guid Salt, string Hash) Hash(string password)
        {
            Guid salt = Guid.NewGuid();
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(password + salt);
            return (Salt: salt, Hash: passwordHash);
        }

        public static bool Verify(string password, string hash, Guid salt)
        {
            return BCrypt.Net.BCrypt.Verify(password + salt, hash);
        }
    }
}
