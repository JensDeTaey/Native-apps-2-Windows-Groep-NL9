using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows_App.Authentication;

namespace Windows_App.Data
{
    public class AuthenticationHandler : AuthenticationSubject
    {
        public static AuthenticationHandler Instance = new AuthenticationHandler();

        //observable property
        private  AuthenticatedStatusEnum authenticatedStatusEnum = AuthenticatedStatusEnum.UNREGISTERED;

        public AuthenticatedStatusEnum AuthenticatedStatus { get {
                return authenticatedStatusEnum;
            }
            private set {
                authenticatedStatusEnum = value;
            }
        }

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

        //Decide authentication status based on the authenticationBearer, which we receive after logging in
        private void DecideAuthenticationStatus()
        {
            if (IDataSource.singleton.authenticationBearer == null)
            {
                this.authenticatedStatusEnum = AuthenticatedStatusEnum.UNREGISTERED;
            }
            else if (IDataSource.singleton.authenticationBearer.IsBusinessAccount)
            {
                this.authenticatedStatusEnum = AuthenticatedStatusEnum.BUSINESSOWNER;
            }
            else
            {
                this.authenticatedStatusEnum = AuthenticatedStatusEnum.LOGGEDIN;
            }
            this.NotifyObservers(authenticatedStatusEnum);
        }

        public void ContinueAfterLogin()
        {
            DecideAuthenticationStatus();
        }

        public void LogOut()
        {
            IDataSource.singleton.LogOut();
            DecideAuthenticationStatus();
        }

    }
}
