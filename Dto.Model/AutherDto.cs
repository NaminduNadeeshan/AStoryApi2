using System;
namespace Dto.Model
{
    public class AutherDto
    {
        public int AutherId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string ProfilePictureUrl { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public bool isSuperAUther { get; set; }

        public string Address { get; set; }
    }

    public class createAutherDto
    {

        public int AutherId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string ProfilePictureUrl { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }
    }

}
