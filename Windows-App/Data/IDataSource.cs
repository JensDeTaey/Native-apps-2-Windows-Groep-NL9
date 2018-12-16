using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows_App.Model;

namespace Windows_App.Data
{
    abstract class IDataSource
    {
        //SINGLETON
        public static IDataSource singleton = new OnlineDataSource();

        public abstract Task<ObservableCollection<Business>> FetchBusinesses();

        public abstract Task<Business> FetchBusinessWithId(int id);

        public abstract Task<ObservableCollection<Promotion>> FetchPromotions();

        public abstract Task<ObservableCollection<Event>> FetchEvents();

        public abstract Task<Boolean> AddEstablishment(int businessId, Establishment establishment);

        public abstract Task<Boolean> EditEstablishment(Establishment establishment);

        public abstract Task<Boolean> DeleteEstablishment(Establishment establishment);



    }
}
