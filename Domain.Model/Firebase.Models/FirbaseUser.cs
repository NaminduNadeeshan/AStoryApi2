using System;
namespace Domain.Model.Firebase.Models
{
    public class FirbaseUser
    {
        public string email { get; set; }

        public string password { get; set; }

        public bool returnSecureToken { get; set; }
    }
}
