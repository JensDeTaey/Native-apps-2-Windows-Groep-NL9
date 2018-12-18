﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows_App.Model;
using Windows_App.ViewModel;

namespace Windows_App.Data
{
    class MockDataSource : IDataSource
    {
        #region User Actions
        protected override Task<AuthenticationBearer> GetAuthenticationBearer(string email, string password)
        {
            return Task<AuthenticationBearer>.Factory.StartNew(() => {
                if (email.ToLower().Contains("business"))
                {
                    return DummyDataSource.BusinessUserAuthenticationBearer;
                }
                else if (email.ToLower().Contains("test"))
                {
                    //Make a certain user always fail login
                    return null;
                }
                else
                {
                    return DummyDataSource.UserAuthenticationBearer;
                }
            });
        }
        public override Task<bool> Register(RegisterViewModel registerViewModel)
        {
            throw new NotImplementedException();
        }
        public override Task<ObservableCollection<Notification>> FetchNotifications()
        {
            throw new NotImplementedException();
        }

        public override Task<bool> ClearNotifications()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Main Page Getters
        public override Task<ObservableCollection<Business>> FetchBusinesses()
        {
            return Task<ObservableCollection<Business>>.Factory.StartNew(() => {
                return new ObservableCollection<Business>(DummyDataSource.Businesses);
            });
        }

        public override Task<ObservableCollection<Event>> FetchEvents()
        {
            return Task<ObservableCollection<Event>>.Factory.StartNew(() => {
                return new ObservableCollection<Event>(DummyDataSource.Events);
            });
        }

        public override Task<ObservableCollection<Promotion>> FetchPromotions()
        {
            return Task<ObservableCollection<Promotion>>.Factory.StartNew(() => {
                return new ObservableCollection<Promotion>(DummyDataSource.Promotions);
            });
        }

        public override Task<ObservableCollection<Business>> FetchSubscribedBusinesses()
        {
            return Task<ObservableCollection<Business>>.Factory.StartNew(() => {
                return new ObservableCollection<Business>(DummyDataSource.Businesses);
            });
        }
        #endregion

        #region Business Actions
        public override Task<Business> FetchBusinessWithId(int id)
        {
            return Task<Business>.Factory.StartNew(() => {
                return DummyDataSource.Businesses.Find(b => b.Id == id);
            });
        }

        public override Task<Business> FetchMyBusiness()
        {
            return Task<Business>.Factory.StartNew(() =>
            {
                return DummyDataSource.BusinessIkea;
            });
        }

        public override Task<bool> EditBusiness(Business business)
        {
            throw new NotImplementedException();
        }

        public override Task<bool> SubscribeToBusiness(int businessId)
        {
            throw new NotImplementedException();
        }

        public override Task<bool> UnsubscribeFromBusiness(int businessId)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Establishment CRUD
        public override Task<bool> AddEstablishment(int businessId, Establishment establishment)
        {
            throw new NotImplementedException();
        }

        public override Task<bool> EditEstablishment(Establishment establishment)
        {
            throw new NotImplementedException();
        }

        public override Task<bool> DeleteEstablishment(Establishment establishment)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Promotion CRUD
        public override Task<bool> AddPromotion(int establishmentId, Promotion promotion)
        {
            throw new NotImplementedException();
        }

        public override Task<bool> EditPromotion(Promotion promotion)
        {
            throw new NotImplementedException();
        }

        public override Task<bool> DeletePromotion(Promotion promotion)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Event CRUD
        public override Task<bool> AddEvent(int establishmentId, Event @event)
        {
            throw new NotImplementedException();
        }

        public override Task<bool> EditEvent(Event @event)
        {
            throw new NotImplementedException();
        }

        public override Task<bool> DeleteEvent(Event @event)
        {
            throw new NotImplementedException();
        }


        #endregion

    }
}
