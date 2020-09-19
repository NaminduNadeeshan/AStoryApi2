using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entity
{
    public class Auther
    {

        [Key]
        public int AutherId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string ProfilePictureUrl { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public bool SuperAuther { get; set; }

        public AutherBankDetails BankDetails { set; get; }

        public virtual ICollection<Story> stories { get; set; }

    }
}



