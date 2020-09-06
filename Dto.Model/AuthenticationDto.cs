using System;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace Dto.Model
{
    public class AuthenticationDto
    {
        public string email { get; set; }

        public string password { get; set; }

        public bool returnSecureToken { get; set; }

        public string userType { get; set; }
    }

    public class FirebaseSignUpResponseDto
    {
        public string idToken { get; set; }

        public string email { get; set; }

        public string refreshToken { get; set; }

        public string expiresIn { get; set; }

        public string localId { get; set; }

        public String error { get; set; }

    }

    public class FirebaseSignupRequest
    {
        public string email { get; set; }

        public string password { get; set; }

        public bool returnSecureToken { get; set; }
    }

    public class FirebaseIdTokenRequest
    {
        public string grant_type { get; set; }

        public string refresh_token { get; set; }
    }

    public class FirebaseIdTokenResponse
    {
        public string expires_in { get; set; }

        public string token_type { get; set; }

        public string refresh_token { get; set; }

        public string id_token { get; set; }

        public string user_id { get; set; }

        public string project_id { get; set; }

        public string error { get; set; }
    }

}