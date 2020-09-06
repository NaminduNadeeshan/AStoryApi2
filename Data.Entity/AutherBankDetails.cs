using System;
using System.ComponentModel.DataAnnotations;

namespace Data.Entity
{
    public class AutherBankDetails
    {
        [Key]
        public int bankDetailsId { get; set; }

        public string bankName { get; set; }

        public string branchName { get; set; }

        public string bankAccountNumber { get; set; }

        public Auther auther { get; set; }

        public int autherId { get; set; }
    }
}
