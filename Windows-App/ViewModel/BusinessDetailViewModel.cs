using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows_App.Model;

namespace Windows_App.ViewModel
{
    public class BusinessDetailViewModel
    {
        public Business Business { get; }
        public List<Establishment> Establishments { get; set; }
        public List<Business> Businesses { get; set; }

        public BusinessDetailViewModel()
        {
            Establishments = DummyDataSource.Establishments;
            Businesses = DummyDataSource.Businesses;
        }

        public BusinessDetailViewModel(Business business)
        {
            this.Business = business;
            
        }

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

    }
}
