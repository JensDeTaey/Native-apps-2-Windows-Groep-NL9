using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Windows_App.Data
{
    public class AuthenticationBearer
    {
        public string AccessToken { get; private set; }
        private readonly DateTime expireDate;
        //Check if expire time lies before the current time
        public bool IsExpired() => DateTime.Compare(expireDate, DateTime.Now) < 0;
        public bool IsBusinessAccount { get; private set; }

        public AuthenticationBearer(string AccessToken, DateTime ExpireDate, bool IsBusinessAccount)
        {
            this.AccessToken = AccessToken;
            this.expireDate = ExpireDate;
            this.IsBusinessAccount = IsBusinessAccount;
        }
    }
}
