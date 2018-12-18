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
    public class BusinessDetailViewModel : INotifyPropertyChanged
    {
        public int BusinessId { get; set; }
        public Business Business { get; set; }
        public List<Establishment> Establishments { get; set; }
        //public List<Business> Businesses { get; set; }

        public BusinessDetailViewModel(int businessId)
        {
            this.BusinessId = businessId;
        }

        public async Task LoadData()
        {
            await OnlineDataSource.singleton.FetchBusinessWithId(BusinessId).ContinueWith(t =>
            {
                this.Business = t.Result;
                TriggerBusinessChanged();
                return;

            }, CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
        }

        public event PropertyChangedEventHandler PropertyChanged;


        public bool isSubscribedTo()
        {
            return Business.IsSubscribedTo;
        }

        public async Task<Boolean> SubscribeClicked()
        {
            if(this.Business == null)
            {
                return false;
            }
            if (this.Business.IsSubscribedTo)
            {
                return await IDataSource.singleton.UnsubscribeFromBusiness(this.Business.Id).ContinueWith(t =>
                {
                    if(t.Result)
                    {
                        this.Business.IsSubscribedTo = false;
                    }
                    return t.Result;
                }, CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
            } else
            {
                return await IDataSource.singleton.SubscribeToBusiness(this.Business.Id).ContinueWith(t =>
                {
                    if (t.Result)
                    {
                        this.Business.IsSubscribedTo = true;
                    }
                    
                    return t.Result;
                }, CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
            }
                
        }

        public void TriggerBusinessChanged()
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Business"));
        }

        public Promotion getPromotion(object tag)
        {
            return (from sublist in Business.Establishments
                         from item in sublist.Promotions
                         where item.Id == (int)tag
                         select item).FirstOrDefault();
        }

    }
}


/*OnlineDataSource.singleton.fetchBusinessWithId(business.Id).ContinueWith(t =>
            {
                this.Business = t.Result;
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Business"));
            }, CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());*/
