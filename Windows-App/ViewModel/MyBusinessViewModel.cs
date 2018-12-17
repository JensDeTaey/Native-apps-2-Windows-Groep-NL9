using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows_App.Data;
using Windows_App.Model;

namespace Windows_App.ViewModel
{
    public class MyBusinessViewModel : INotifyPropertyChanged
    {
        public Business Business { get; set; }
        public User User { get; set; }
       
        public Establishment Establishment { get; set; }
        public Promotion Promotion { get; set; }
        public Event Event { get; set; }
        public MyBusinessViewModel()
        {
            //Business = DummyDataSource.BusinessIkea;
            //User = DummyDataSource.user1;
            //Establishment = DummyDataSource.EstablishmentIkeaGent;


            IDataSource.singleton.FetchMyBusiness().ContinueWith(t =>
            {
                if (t.Result != null)
                {
                    this.Business = t.Result;
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Business"));
                }
            }, CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void fillRightEstablishment (object tag)
        {
            Establishment = Business.Establishments.FirstOrDefault(esta => esta.Id == (int)tag);
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Establishment"));
        }

        public void FillRightPromotion(object tag)
        {
            Promotion = (from sublist in Business.Establishments
                           from item in sublist.Promotions
                           where item.Id == (int)tag
                           select item).FirstOrDefault();
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Promotion"));
        }

        public void FillRightEvent(object tag)
        {
            Event = (from sublist in Business.Establishments
                         from item in sublist.Events
                     where item.Id == (int)tag
                         select item).FirstOrDefault();
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Event"));
        }

        public void DeleteBusiness()
        {
            // DIT MOGEN ZE NIET DOEN !!! >:(
        }

        public void DeleteEstablishment()
        {
            if(this.Establishment == null)
            {
                return;
            }
            IDataSource.singleton.DeleteEstablishment(this.Establishment).ContinueWith(t =>
            {
                if (t.Result)
                {
                    this.Business.Establishments.Remove(this.Establishment);
                    this.Establishment = null;
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Establishment"));
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Business"));
                }
            }, CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
        }

        public void DeletePromotion()
        {
            if (this.Promotion == null)
            {
                return;
            }
            IDataSource.singleton.DeletePromotion(this.Promotion).ContinueWith(t =>
            {
                if (t.Result)
                {
                    this.Business.Establishments.ForEach(e =>
                    {
                        e.Promotions.Remove(this.Promotion);
                    });
                    this.Promotion = null;
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Business"));
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Promotion"));
                }
            }, CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
        }

        public void DeleteEvent()
        {
            if (this.Event == null)
            {
                return;
            }
            IDataSource.singleton.DeleteEvent(this.Event).ContinueWith(t =>
            {
                if (t.Result)
                {
                    this.Business.Establishments.ForEach(e =>
                    {
                        e.Events.Remove(this.Event);
                    });
                    this.Event = null;
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Business"));
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Event"));
                }
            }, CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
        }
        public void SaveBusiness(Business business)
        {
            if(this.Business == null)
            {
                return;
            }
            business.Id = this.Business.Id;
            IDataSource.singleton.EditBusiness(business).ContinueWith(t =>
            {
                if (t.Result)
                {

                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Business"));
                }
            }, CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());

        }

        public void SaveEstablishment(Establishment establishment)
        {
            if (this.Establishment == null)
            {
                return;
            }
            establishment.Id = this.Establishment.Id;
            IDataSource.singleton.EditEstablishment(establishment).ContinueWith(t =>
            {
                if (t.Result)
                {
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Establishment"));
                }
            }, CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
        }

        public void SavePromotion(Promotion promotion)
        {
            if (this.Promotion == null)
            {
                return;
            }
            promotion.Id = this.Promotion.Id;
            IDataSource.singleton.EditPromotion(promotion).ContinueWith(t =>
            {
                if (t.Result)
                {
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Promotion"));
                }
            }, CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
        }

        public void SaveEvent(Event @event)
        {
            if (this.Event == null)
            {
                return;
            }
            @event.Id = this.Event.Id;
            IDataSource.singleton.EditEvent(Event).ContinueWith(t =>
            {
                if (t.Result)
                {
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Event"));
                }
            }, CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
        }
    }
}
