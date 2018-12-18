using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows_App.Data;
using Windows_App.Model;

namespace Windows_App.ViewModel
{
    public class SubsribedBusinessesViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Business> Businesses { get; set; }
        public List<Promotion> Promotions { get; set; }
        public List<Event> Events { get; set; }
        public SubsribedBusinessesViewModel()
        {
            Businesses = new ObservableCollection<Business>();
            IDataSource.singleton.FetchSubscribedBusinesses().ContinueWith(t =>
            {
                Businesses = t.Result;
                Events = Businesses.SelectMany(b => b.Establishments).SelectMany(e => e.Events).ToList();
                Promotions = Businesses.SelectMany(b => b.Establishments).SelectMany(e => e.Promotions).ToList();
                if (PropertyChanged != null)
                {
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Businesses"));
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Promotions"));
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Events"));
                }
                
            }, CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
