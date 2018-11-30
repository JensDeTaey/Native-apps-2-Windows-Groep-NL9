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
        private Business Business { get; }
        List<Establishment> Establishments { get; }

        public BusinessDetailViewModel(Business business)
        {
            this.Business = business;
            this.Establishments = business.Establishments;
        }

    }
}
