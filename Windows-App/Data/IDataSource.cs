using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows_App.Model;

namespace Windows_App.Data
{
    abstract class IDataSource
    {
        //SINGLETON
        public static IDataSource singleton = new MockDataSource();

        protected AuthenticationBearer authenticationBearer;

        public Task<bool> LogIn(string username, string password)
        {
            //Call the authenticationBearer with username and password
            return GetAuthenticationBearer(username, password).ContinueWith(t =>
                           {
                               //If something went wrong the response will be null
                               if(t != null)
                               {
                                   //store the authenticationBearer
                                   authenticationBearer = t.Result;
                                   return true;
                               }
                                   return false;
                           }, CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
        }

        protected abstract Task<AuthenticationBearer> GetAuthenticationBearer(string username, string password);

        public abstract Task<ObservableCollection<Business>> FetchBusinesses();

        public abstract Task<Business> FetchBusinessWithId(int id);

        public abstract Task<ObservableCollection<Promotion>> FetchPromotions();

        public abstract Task<ObservableCollection<Event>> FetchEvents();
    }
}
