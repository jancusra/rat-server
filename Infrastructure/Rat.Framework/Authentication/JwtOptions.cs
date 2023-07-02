namespace Rat.Framework.Authentication
{
    public partial class JwtOptions
    {
        public JwtOptions()
        {
            AuthorizationCookieKey = "Authorization";
        }

        public string AuthorizationCookieKey { get; }

        public string SecretKey { get; set; }

        public int ExpiryMinutes { get; set; }
    }
}
