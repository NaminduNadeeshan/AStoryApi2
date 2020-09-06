using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data.Entity
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string ProfileImageUrl { get; set; }

        public string PhoneNumber { get; set; }

        public string UserType { get; set; }

        public string UserAppId { get; set; }

        public virtual ICollection<Subscription> SubscribedStories {get;set;}

    }
}
