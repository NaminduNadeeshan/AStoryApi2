using System;
namespace Dto.Model
{
    public class Authentication
    {
        public string Authority { get; set; }

        public string ValidIssuer { get; set; }

        public string ValidAudience { get; set; }

        public string SignUpUrl { get; set; }

        public string RefreshTokenUrl { get; set; }

        public string FirebaseApiKey { get; set; }

        public string SignInUrl { get; set; }
    }
}
