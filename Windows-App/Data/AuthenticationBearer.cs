using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Windows_App.Data
{
    public class AuthenticationBearer
    {
        public string AccessToken { get; set; }
        private DateTime expireDate;
        public DateTime ExpireDate
        {
            set { expireDate = value; }
        }
        //Check if expire time lies before the current time
        public bool IsExpired() => DateTime.Compare(expireDate, DateTime.Now) < 0; 
        public bool IsBusinessAccount { get; set; }
    }
}
