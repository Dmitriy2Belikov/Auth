using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Auth.DataLayer
{
    public class AuthOptions
    {
        public const string REFRESH_TOKEN_COOKIE = "refresh";

        public const string ISSUER = "localhost";
        public const string AUDIENCE = "localhost";
        const string KEY = "test_security_key";
        public const int ACCEESS_TOKEN_LIFETIME_HOURS = 1;

        public const int REFRESH_TOKEN_LIFETIME_DAYS = 60;

        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
