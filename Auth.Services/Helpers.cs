namespace Auth.Services
{
    public static class Helpers
    {
        public static string HashPassword(string password)
        {
            var hashed = BCrypt.Net.BCrypt.HashPassword(password);

            return hashed;
        }

        public static bool Verify(string password, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }
    }
}
