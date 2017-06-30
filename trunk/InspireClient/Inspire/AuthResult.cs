using System;

namespace Inspire
{
   public class AuthResult
    {
        public AuthResult()
        {
            TrialVersion = true;
        }

        public bool UserAuthorized { get; set; }
        public bool TrialVersion { get; set; }
        public DateTime RegDate{ get; set; }
        public string Message { get; set; }
    }
}
