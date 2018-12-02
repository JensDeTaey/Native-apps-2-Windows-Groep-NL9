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

        public BusinessDetailViewModel(Business business)
        {
            this.Business = business;
        }

        public List<Establishment> getEstablishments()
        {
            return Business.Establishments;
        }

    }
}
