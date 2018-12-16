using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Windows_App.Data
{
    public class AuthenticationHandler
    {
        public static AuthenticationHandler Instance = new AuthenticationHandler();

        private void CheckForInternetConnection()
        {
            if (!NetworkInterface.GetIsNetworkAvailable())
            {
                //TODO show alert
                throw new Exception("No internet");
            }
        }

        public Task<bool> LogIn(string email, string password)
        {
            CheckForInternetConnection();

            return IDataSource.singleton.LogIn(email, password).ContinueWith(t =>
                {
                    return t.Result;
                }, CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
        }

        public void ContinueAfterLogin()
        {
            
        }
    }
}
