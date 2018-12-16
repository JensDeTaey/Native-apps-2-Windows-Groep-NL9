using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.UI.Core;
using Windows_App.Data;
using Windows_App.Model;

namespace Windows_App.ViewModel
{
    public class BusinessesViewModel : INotifyPropertyChanged
    {

            public ObservableCollection<Business> Businesses { get; set; }
            public BusinessesViewModel()
            {
            //Businesses = new ObservableCollection<Business>(DummyDataSource.Businesses);
            Businesses = new ObservableCollection<Business>();
            IDataSource.singleton.FetchBusinesses().ContinueWith(t =>
            {
                Businesses = t.Result;
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Businesses"));
            }, CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
        }


        public event PropertyChangedEventHandler PropertyChanged;

        /*public ObservableCollection<Business> Businesses { get; set; }
        public BusinessesViewModel()
        {
            Businesses = new ObservableCollection<Business>();
            OnlineDataSource.singleton.fetchBusinesses().ContinueWith(t =>
            {
                Businesses = t.Result;
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Businesses"));

            }, CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
        }

        */




    }

}
