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

        public SubsribedBusinessesViewModel()
        {
            Businesses = new ObservableCollection<Business>();
            IDataSource.singleton.FetchBusinesses().ContinueWith(t =>
            {
                Businesses = t.Result;
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Businesses"));
            }, CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
