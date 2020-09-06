using System;
namespace Dto.Model
{
    public class UserDto
    {
        public string UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string ProfileImageUrl { get; set; }

        public string PhoneNumber { get; set; }

        public string UserType { get; set; }

        public string refreshToken { get; set; }

        public string accessToken { get; set; }

        public string expiresIn { get; set; }

        public String error { get; set; }
    }
}
