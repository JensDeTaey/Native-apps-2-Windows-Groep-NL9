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

        public List<String> getAdresses()
        {
            List<String> adresses = new List<string>();
            Business.Establishments.ForEach(esta => adresses.Add(esta.Address));
            return adresses;
        }

    }
}
