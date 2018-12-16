using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows_App.Model;

namespace Windows_App.Data
{
    abstract class IDataSource
    {
        //SINGLETON
        public static IDataSource singleton = new OnlineDataSource();


        #region User Actions
        //Robin's methods should come here, Login and Register
        #endregion


        #region Main Pages Getters
        public abstract Task<ObservableCollection<Business>> FetchBusinesses();
        public abstract Task<ObservableCollection<Promotion>> FetchPromotions();
        public abstract Task<ObservableCollection<Event>> FetchEvents();
        public abstract Task<ObservableCollection<Business>> FetchSubscribedBusinesses();
        #endregion

        #region Business Actions
        public abstract Task<Business> FetchBusinessWithId(int businessId);
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
