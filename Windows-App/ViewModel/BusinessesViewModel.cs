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
            Businesses = new ObservableCollection<Business>();
            IDataSource.singleton.FetchBusinesses().ContinueWith(t =>
            {
                if(t.Result != null)
                {
                    Businesses = t.Result;
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Businesses"));
                }
                
            }, CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public void FilterBusinesses(string filter)
        {
            //Filter on business name and on category
            Businesses = new ObservableCollection<Business>(Businesses.Where(business => 
            business.Name.ToLower().Contains(filter.ToLower()) ||
            business.Category.ToLower().Contains(filter.ToLower())
            ));
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Businesses"));

        }

    }

}
