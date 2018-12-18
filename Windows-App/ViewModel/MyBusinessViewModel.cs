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
                    TriggerBusinessUpdate();
                }
            }, CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void fillRightEstablishment (object tag)
        {
            Establishment = Business.Establishments.FirstOrDefault(esta => esta.Id == (int)tag);
            TriggerEstablishmentUpdate();
        }

        public void FillRightPromotion(object tag)
        {
            Promotion = (from sublist in Business.Establishments
                           from item in sublist.Promotions
                           where item.Id == (int)tag
                           select item).FirstOrDefault();
            TriggerPromotionUpdate();
        }

        public void FillRightEvent(object tag)
        {
            Event = (from sublist in Business.Establishments
                         from item in sublist.Events
                     where item.Id == (int)tag
                         select item).FirstOrDefault();
            TriggerEventUpdate();
        }

        public async Task<Boolean> DeleteEstablishment()
        {
            if(this.Establishment == null)
            {
                return false;
            } 
                return await IDataSource.singleton.DeleteEstablishment(this.Establishment).ContinueWith(t =>
                {
                    if (t.Result)
                    {
                        this.Business.Establishments.Remove(this.Establishment);
                        this.Establishment = null;
                        TriggerEstablishmentUpdate();
                        TriggerBusinessUpdate();
                    }
                    return t.Result;
                }, CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
            
        }

        public async Task<Boolean> DeletePromotion()
        {
            if (this.Promotion == null)
            {
                return false;
            }
            return await IDataSource.singleton.DeletePromotion(this.Promotion).ContinueWith(t =>
            {
                if (t.Result)
                {
                    this.Business.Establishments.ForEach(e =>
                    {
                        e.Promotions.Remove(this.Promotion);
                    });
                    this.Promotion = null;
                    TriggerBusinessUpdate();
                    TriggerPromotionUpdate();
                }
                return t.Result;
            }, CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
        }

        public async Task<Boolean> DeleteEvent()
        {
            if (this.Event == null)
            {
                return false;
            }
            return await IDataSource.singleton.DeleteEvent(this.Event).ContinueWith(t =>
            {
                if (t.Result)
                {
                    this.Business.Establishments.ForEach(e =>
                    {
                        e.Events.Remove(this.Event);
                    });
                    this.Event = null;
                    TriggerBusinessUpdate();
                    TriggerEventUpdate();
                }
                return t.Result;
            }, CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
        }
        public async Task<Boolean> SaveBusiness(Business business)
        {
            if(this.Business == null)
            {
                return false;
            }
            business.Id = this.Business.Id;
            return await IDataSource.singleton.EditBusiness(business).ContinueWith(t =>
            {
                if (t.Result)
                {
                    this.Business.Name = business.Name;
                    this.Business.Description = business.Description;
                    this.Business.Category = business.Category;
                    this.Business.LinkWebsite = business.LinkWebsite;
                    this.Business.Picture = business.Picture;
                    TriggerBusinessUpdate();
                }
                return t.Result;
            }, CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());

        }

        public async Task<Boolean> SaveEstablishment(Establishment establishment)
        {
            if (this.Establishment == null)
            {
                return false;
            }
            establishment.Id = this.Establishment.Id;
            return await IDataSource.singleton.EditEstablishment(establishment).ContinueWith(t =>
            {
                if (t.Result)
                {
                    this.Establishment.Name = establishment.Name;
                    this.Establishment.PhoneNumber = establishment.PhoneNumber;
                    this.Establishment.Picture = establishment.Picture;
                    this.Establishment.Address = establishment.Address;
                    this.Establishment.AllOpeningHours = establishment.OpeningHours;
                    this.Establishment.Email = establishment.Email;
                    TriggerEstablishmentUpdate();
                }
                return t.Result;
            }, CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
        }

        public async Task<Boolean> SavePromotion(Promotion promotion)
        {
            if (this.Promotion == null)
            {
                return false;
            }
            promotion.Id = this.Promotion.Id;
            return await IDataSource.singleton.EditPromotion(promotion).ContinueWith(t =>
            {
                if (t.Result)
                {
                    this.Promotion.Name = promotion.Name;
                    this.Promotion.Description = promotion.Description;
                    this.Promotion.IsDiscountCoupon = promotion.IsDiscountCoupon;
                    this.Promotion.StartDate = promotion.StartDate;
                    this.Promotion.EndDate = promotion.EndDate;
                    TriggerPromotionUpdate();
                }
                return t.Result;
            }, CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
        }

        public async Task<Boolean> SaveEvent(Event @event)
        {
            if (this.Event == null)
            {
                return false;
            }
            @event.Id = this.Event.Id;
            return await IDataSource.singleton.EditEvent(Event).ContinueWith(t =>
            {
                if (t.Result)
                {
                    this.Event.Name = @event.Name;
                    this.Event.Description = @event.Description;
                    this.Event.StartDate = @event.StartDate;
                    this.Event.EndDate = @event.EndDate;
                    TriggerEventUpdate();
                }
                return t.Result;
            }, CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
        }

        public async Task<Boolean> AddEstablishment(Establishment establishment)
        {
            if(this.Business == null)
            {
                return false;
            }

            return await IDataSource.singleton.AddEstablishment(this.Business.Id,establishment).ContinueWith(t =>
            {
                if (t.Result)
                {
                    TriggerBusinessUpdate();
                }
                return t.Result;
            }, CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
        }

        public async Task<Boolean> AddPromotion(Promotion promotion)
        {
            if (this.Establishment == null)
            {
                return false;
            }

            return await IDataSource.singleton.AddPromotion(this.Establishment.Id, promotion).ContinueWith(t =>
            {
                if (t.Result)
                {
                    TriggerBusinessUpdate();
                }
                return t.Result;
            }, CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
        }

        public async Task<Boolean> AddEvent(Event @event)
        {
            if (this.Establishment == null)
            {
                return false;
            }

            return await IDataSource.singleton.AddEvent(this.Establishment.Id, @event).ContinueWith(t =>
            {
                if (t.Result)
                {
                    TriggerBusinessUpdate();
                }
                return t.Result;
            }, CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
        }

        public void TriggerBusinessUpdate()
        {
            if(PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Business"));
            }
            
        }

        public void TriggerEstablishmentUpdate()
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Establishment"));
            }
            
        }

        public void TriggerEventUpdate()
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Event"));
            }
            
        }

        public void TriggerPromotionUpdate()
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Promotion"));
            }
            
        }

    }
}
