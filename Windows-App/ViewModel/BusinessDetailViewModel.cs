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

        public BusinessDetailViewModel(Business business)
        {
            OnlineDataSource.singleton.fetchBusinessWithId(business.Id).ContinueWith(t =>
            {
                this.Business = t.Result;
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Business"));
            }, CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public List<Establishment> getEstablishments()
        {
            return Business.Establishments;
        }
    }
}
