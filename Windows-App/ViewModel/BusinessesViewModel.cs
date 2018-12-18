using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;
using Windows_App.Data;
using Windows_App.Model;

namespace Windows_App.ViewModel
{
    public class BusinessesViewModel : INotifyPropertyChanged
    {
        private Collection<Business> SortedAllBusinesses { get; set; }
        private ObservableCollection<Business> businesses;

        public ObservableCollection<Business> Businesses
        {
            get { return businesses; }
            set
            {
                businesses = value;
                HasNoItems = Businesses.Count > 0;
                NotifyPropertyChanged();
            }
        }

        private bool hasNoItems;
        public bool HasNoItems
        {
            get
            {
                return hasNoItems;
            }
            set
            {
                if (hasNoItems != value)
                {
                    hasNoItems = value;
                    NotifyPropertyChanged();
                }
            }
        }

        protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public BusinessesViewModel()
        {
            SortedAllBusinesses = new Collection<Business>();
            businesses = new ObservableCollection<Business>();
            IDataSource.singleton.FetchBusinesses().ContinueWith(t =>
            {
                if (t.Result != null)
                {
                    SortedAllBusinesses = t.Result;
                    Businesses = t.Result;
                    SortBusinessesBySubscribers(false);
                }

            }, CancellationToken.None, TaskContinuationOptions.None, TaskScheduler.FromCurrentSynchronizationContext());
        }

        public void SortBusinessesBySubscribers(bool ascending)
        {
            //Filter on business name and on category
            List<Business> sortedAllBusinesses = new List<Business>(SortedAllBusinesses);
            sortedAllBusinesses.Sort((bus1, bus2) =>
                   ascending ? bus1.NumberOfSubscribers - bus2.NumberOfSubscribers : bus2.NumberOfSubscribers - bus1.NumberOfSubscribers
            );
            SortedAllBusinesses = new ObservableCollection<Business>(sortedAllBusinesses);
            //Sort the filtered list
            List<Business> sortedBusinesses = new List<Business>(Businesses);
            sortedBusinesses.Sort((bus1, bus2) =>
                   ascending ? bus1.NumberOfSubscribers - bus2.NumberOfSubscribers : bus2.NumberOfSubscribers - bus1.NumberOfSubscribers
            );
            Businesses = new ObservableCollection<Business>(sortedBusinesses);
        }

        public void FilterBusinesses(string filter)
        {
            //Filter on business name and on category
            Businesses = new ObservableCollection<Business>(SortedAllBusinesses.Where(business =>
            business.Name.ToLower().Contains(filter.ToLower()) ||
            business.Category.ToLower().Contains(filter.ToLower())
            ));
        }

    }

}
