using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows_App.Model;

namespace Windows_App.ViewModel
{
    public class BusinessDetailViewModel : INotifyPropertyChanged
    {
        public Business Business { get; set; }
        public List<Establishment> Establishments { get; set; }
        public List<Business> Businesses { get; set; }

        public BusinessDetailViewModel(Business business)
        {
            this.Business = business;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public List<Establishment> GetEstablishments()
        {
            return Business.Establishments;
        }

        public Establishment FindEstablishment(int establishmentID)
        {
            return Establishments.Find(esta => esta.Id == establishmentID);
        }

        public Business FindBusiness(int businessID)
        {
            return Businesses.Find(bis => bis.Id == businessID);
        }

        public bool isSubscribedTo()
        {
            return Business.IsSubscribedTo;
        }

    }
}


/*OnlineDataSource.singleton.fetchBusinessWithId(business.Id).ContinueWith(t =>
            {
                this.Business = t.Result;
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Business"));
            }, CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());*/
