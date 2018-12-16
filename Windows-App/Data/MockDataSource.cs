using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows_App.Model;

namespace Windows_App.Data
{
    class MockDataSource : IDataSource
    {
        public override Task<ObservableCollection<Business>> FetchBusinesses()
        {
            return Task<ObservableCollection<Business>>.Factory.StartNew(() => {
                return new ObservableCollection<Business>(DummyDataSource.Businesses);
            });
        }

        public override Task<Business> FetchBusinessWithId(int id)
        {
            return Task<Business>.Factory.StartNew(() => {
                return DummyDataSource.Businesses.Find(b => b.Id == id);
            });
        }

        public override Task<ObservableCollection<Event>> FetchEvents()
        {
            return Task<ObservableCollection<Event>>.Factory.StartNew(() => {
                return new ObservableCollection<Event>(DummyDataSource.Events);
            });
        }

        public override Task<ObservableCollection<Promotion>> FetchPromotions()
        {
            return Task<ObservableCollection<Promotion>>.Factory.StartNew(() => {
                return new ObservableCollection<Promotion>(DummyDataSource.Promotions);
            });
        }
    }
}
