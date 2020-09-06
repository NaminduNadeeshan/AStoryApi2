using System;
using Dto.Model;

namespace Services.AuthenticationService
{
    public interface IAuthentication
    {
        UserDto SignUpUser(AuthenticationDto user);

        UserDto SignInUser(AuthenticationDto user);

        FirebaseIdTokenResponse getIdTokenByRefreshToken(FirebaseIdTokenRequest token);

        UserDto SocialLogin(UserDto user);

    }
}
