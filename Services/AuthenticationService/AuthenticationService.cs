using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Data.Entity;
using Domain.Model.ErrorLog.Model;
using Dto.Model;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Repository.CommonRepository;
using Repository.UserRepository;
using Services.ErrorLogService;

namespace Services.AuthenticationService
{
    public class AuthenticationService : IAuthentication
    {

        private readonly IOptions<Authentication> _authencationsSettings;
        private readonly IErrorLogService _errorService;
        private readonly IGenaricRepository<User> _userRepo;
        private readonly IUserRepository _userDiffRepo;

        public AuthenticationService(IOptions<Authentication> authenticationSettings, IErrorLogService errorService, IGenaricRepository<User> userRepo, IUserRepository userDiffRepo)
        {
            _authencationsSettings = authenticationSettings;
            _errorService = errorService;
            _userRepo = userRepo;
            _userDiffRepo = userDiffRepo;
        }

        public UserDto SignInUser(AuthenticationDto user)
        {
            try
            {
                var firebaseUser = new FirebaseSignupRequest
                {
                    email = user.email,
                    password = user.password,
                    returnSecureToken = true
                };
                var response = CallFireBaseToSignIn(firebaseUser).Result;

                return response;
            }
            catch (Exception e)
            {
                _errorService.logErrorToServer(new ErrorLog { ErrorFile = "AuthenticationService", errorException = e.ToString(), ErrorFunction = "SignInUser" });
                throw e;
            }
        }

        public UserDto SignUpUser(AuthenticationDto user)
        {
            try
            {
                var firebaseUser = new FirebaseSignupRequest
                {

                    email = user.email,
                    password = user.password,
                    returnSecureToken = true
                };

                var users = CallFirbaseSignup(firebaseUser, user.userType).Result;

                return users;
            }
            catch (Exception e)
            {
                _errorService.logErrorToServer(new ErrorLog { ErrorFile = "AuthenticationService", errorException = e.ToString(), ErrorFunction = "SignUpUser" });
                throw e;
            }
        }

        public FirebaseIdTokenResponse getIdTokenByRefreshToken(FirebaseIdTokenRequest token)
        {
            try
            {
                return CallFirebaseToGetIdToken(token).Result;
            }
            catch (Exception e)
            {
                _errorService.logErrorToServer(new ErrorLog { ErrorFile = "AuthenticationService", errorException = e.ToString(), ErrorFunction = "getIdTokenByRefreshToken" });
                throw e;
            }
        }

        public UserDto SocialLogin(UserDto user)
        {

            var existingUser = _userDiffRepo.GetUserByEmail(user.Email);

            if (!existingUser.Any())
            {

                try
                {
                    var userToDb = new User
                    {
                        Email = user.Email,
                        FirstName = user.FirstName,
                        LastName = user.LastName,
                        PhoneNumber = user.PhoneNumber,
                        ProfileImageUrl = user.ProfileImageUrl,
                        UserAppId = user.UserId,
                        UserType = user.UserType
                    };
                    _userRepo.Insert(userToDb);
                    return user;
                }
                catch (Exception e)
                {
                    _errorService.logErrorToServer(new ErrorLog { ErrorFile = "AuthenticationService", errorException = e.ToString(), ErrorFunction = "SocialLogin" });
                    throw e;
                }
            } else
            {
                var returnUser = new UserDto { };
                foreach(User users in existingUser)
                {
                    returnUser = new UserDto
                    {
                        Email = users.Email,
                        FirstName = users.FirstName,
                        LastName = users.LastName,
                        PhoneNumber = users.PhoneNumber,
                        ProfileImageUrl = user.ProfileImageUrl,
                        UserId = user.UserId,
                    };
                }
            }


        }

        private async Task<UserDto> CallFirbaseSignup(FirebaseSignupRequest user, string userType)
        {
            string signUpUrl = $"{_authencationsSettings.Value.SignUpUrl}{_authencationsSettings.Value.FirebaseApiKey}";

            var json = JsonConvert.SerializeObject(user);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            using var client = new HttpClient();

            var result = await client.PostAsync(signUpUrl, data);

            if (!result.IsSuccessStatusCode)
            {
                JObject error = JObject.Parse(result.Content.ReadAsStringAsync().Result);

                return new UserDto
                {
                    error = error.SelectToken("error.message").ToString(),
                };
            }
            else
            {
                FirebaseSignUpResponseDto value = JsonConvert.DeserializeObject<FirebaseSignUpResponseDto>(result.Content.ReadAsStringAsync().Result);

                var values = new User
                {
                    Email = value.email,
                    FirstName = "X",
                    LastName = "Y",
                    PhoneNumber = "182818291",
                    ProfileImageUrl = "2772727721991",
                    UserType = userType,
                    UserAppId = value.localId
                };

                _userRepo.Insert(values);

                var userReturn = new UserDto
                {
                    Email = value.email,
                    FirstName = values.FirstName,
                    LastName = values.LastName,
                    expiresIn = value.expiresIn,
                    UserId = value.localId,
                    PhoneNumber = values.PhoneNumber,
                    ProfileImageUrl = values.ProfileImageUrl,
                    refreshToken = value.refreshToken,
                    UserType = userType,
                    accessToken = value.idToken
                };

                return userReturn;
            }
        }

        private async Task<UserDto> CallFireBaseToSignIn(FirebaseSignupRequest user)
        {
            string signUpUrl = $"{_authencationsSettings.Value.SignInUrl}{_authencationsSettings.Value.FirebaseApiKey}";

            using (HttpClient client = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(user);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                var result = await client.PostAsync(signUpUrl, data);

                if (!result.IsSuccessStatusCode)
                {
                    JObject error = JObject.Parse(result.Content.ReadAsStringAsync().Result);

                    return new UserDto
                    {
                        error = error.SelectToken("error.message").ToString()
                    };
                }
                else
                {
                    FirebaseSignUpResponseDto value = JsonConvert.DeserializeObject<FirebaseSignUpResponseDto>(result.Content.ReadAsStringAsync().Result);

                    //TODO: need to bind with this function retrive data with FirebaseSignUpResponseDto
                    //TODO: Create a new DTO for the expose outside from api for usersDeteils.
                    var signedUser = RetriveSignInUserDetails(value.email);

                    var returnedUser = new UserDto
                    {
                        Email = signedUser.Email,
                        expiresIn = value.expiresIn,
                        FirstName = signedUser.FirstName,
                        LastName = signedUser.LastName,
                        PhoneNumber = signedUser.PhoneNumber,
                        refreshToken = value.refreshToken,
                        ProfileImageUrl = signedUser.ProfileImageUrl,
                        UserType = signedUser.UserType,
                        UserId = signedUser.UserId.ToString(),
                        accessToken = value.idToken
                    };

                    return returnedUser;
                }
            }
        }

        private async Task<FirebaseIdTokenResponse> CallFirebaseToGetIdToken(FirebaseIdTokenRequest token)
        {
            string tokenUrl = $"{_authencationsSettings.Value.RefreshTokenUrl}{_authencationsSettings.Value.FirebaseApiKey}";

            using (HttpClient client = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(token);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                var result = await client.PostAsync(tokenUrl, data);

                if (!result.IsSuccessStatusCode)
                {
                    JObject error = JObject.Parse(result.Content.ReadAsStringAsync().Result);
                    return new FirebaseIdTokenResponse
                    {
                        error = error.SelectToken("error.message").ToString()
                    };
                }
                else
                {
                    FirebaseIdTokenResponse value = JsonConvert.DeserializeObject<FirebaseIdTokenResponse>(result.Content.ReadAsStringAsync().Result);
                    return value;
                }
            }
        }

        private void SaveUserToDatabase()
        {

        }

        private User RetriveSignInUserDetails(string email)
        {
            return _userDiffRepo.GetUserByEmail(email);
        }
    }
}
