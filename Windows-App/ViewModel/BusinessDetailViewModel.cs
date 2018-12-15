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

        public List<Establishment> getEstablishments()
        {
            return Business.Establishments;
        }

        public Establishment getRightEstablishment(int id)
        {
            return Establishments.Find(esta => esta.Id == id);
        }

        public Business getRightBusiness(int id)
        {
            return Businesses.Find(bis => bis.Id == id);
        }

    }
}
