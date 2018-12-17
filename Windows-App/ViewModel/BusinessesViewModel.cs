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
using Windows.UI.Xaml;
using Windows_App.Data;
using Windows_App.Model;

namespace Windows_App.ViewModel
{
    public class BusinessesViewModel : INotifyPropertyChanged
    {
        private Collection<Business> AllBusinesses { get; set; }
        private ObservableCollection<Business> businesses;

        public ObservableCollection<Business> Businesses
        {
            get { return businesses; }
            set
            {
                businesses = value;
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Businesses"));
            }
        }

        private Visibility visibility;
        public Visibility Visibility
        {
            get
            {
                return visibility;
            }
            set
            {
                if (visibility != value)
                {
                    visibility = value;
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Visibility"));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public BusinessesViewModel()
        {
            //Businesses = new ObservableCollection<Business>();
            IDataSource.singleton.FetchBusinesses().ContinueWith(t =>
            {
                if (t.Result != null)
                {
                    AllBusinesses = t.Result;
                    Businesses = new ObservableCollection<Business>(AllBusinesses);
                }

            }, CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
        }

        public void FilterBusinesses(string filter)
        {
            //Filter on business name and on category
            Businesses = new ObservableCollection<Business>(AllBusinesses.Where(business =>
            business.Name.ToLower().Contains(filter.ToLower()) ||
            business.Category.ToLower().Contains(filter.ToLower())
            ));
            Visibility = Businesses.Count >0?Visibility.Collapsed:Visibility.Visible;
        }

    }

}
