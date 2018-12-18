using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows_App.Model;
using Windows_App.ViewModel;

namespace Windows_App.Data
{
    abstract class IDataSource
    {
        //SINGLETON
        public static IDataSource singleton = new OnlineDataSource();

        public AuthenticationBearer authenticationBearer;

        protected abstract Task<AuthenticationBearer> GetAuthenticationBearer(string email, string password);

        #region User Actions
        public abstract Task<bool> Register(RegisterViewModel registerViewModel);

        public Task<bool> LogIn(string email, string password)
        {
            //Call the authenticationBearer with username and password
            return GetAuthenticationBearer(email, password).ContinueWith(t =>
            {
                //If something went wrong the response will be null
                if (t != null && t.Result != null && t.Result.AccessToken != null)
                {
                    //store the authenticationBearer
                    authenticationBearer = t.Result;
                    return true;
                }
                return false;
            }, CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
        }

        public void LogOut()
        {
            this.authenticationBearer = null;
        }

        public abstract Task<ObservableCollection<Notification>> FetchNotifications();

        public abstract Task<Boolean> ClearNotifications();
        #endregion

        #region Main Pages Getters
        public abstract Task<ObservableCollection<Business>> FetchBusinesses();
        public abstract Task<ObservableCollection<Promotion>> FetchPromotions();
        public abstract Task<ObservableCollection<Event>> FetchEvents();
        public abstract Task<ObservableCollection<Business>> FetchSubscribedBusinesses();
        #endregion

        #region Business Actions
        public abstract Task<Business> FetchBusinessWithId(int businessId);
        public abstract Task<Business> FetchMyBusiness();
        public abstract Task<Boolean> EditBusiness(Business business);
        public abstract Task<Boolean> SubscribeToBusiness(int businessId);
        public abstract Task<Boolean> UnsubscribeFromBusiness(int businessId);
        #endregion

        #region Establishment CRUD
        public abstract Task<Boolean> AddEstablishment(int businessId, Establishment establishment);
        public abstract Task<Boolean> EditEstablishment(Establishment establishment);
        public abstract Task<Boolean> DeleteEstablishment(Establishment establishment);
        #endregion

        #region Promotions CRUD
        public abstract Task<Boolean> AddPromotion(int establishmentId, Promotion promotion);
        public abstract Task<Boolean> EditPromotion(Promotion promotion);
        public abstract Task<Boolean> DeletePromotion(Promotion promotion);
        #endregion

        #region Events CRUD
        public abstract Task<Boolean> AddEvent(int establishmentId, Event @event);
        public abstract Task<Boolean> EditEvent(Event @event);
        public abstract Task<Boolean> DeleteEvent(Event @event);
        #endregion


    }
}
