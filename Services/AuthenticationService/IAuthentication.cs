using System;
using System.Collections.Generic;
using Dto.Model;

namespace Services.AuthenticationService
{
    public interface IAuthentication
    {
        UserDto SignUpUser(AuthenticationDto user);

        List<UserDto> SignInUser(AuthenticationDto user);

        FirebaseIdTokenResponse getIdTokenByRefreshToken(FirebaseIdTokenRequest token);

        UserDto SocialLogin(UserDto user);

    }
}
