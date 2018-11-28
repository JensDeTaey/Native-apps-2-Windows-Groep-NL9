using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows_App.Model;

namespace Windows_App.ViewModel
{
    public class BusinessesViewModel
    {
        public ObservableCollection<Business> Businesses { get; set; }
        public BusinessesViewModel()
        {
            Businesses = new ObservableCollection<Business>(DummyDataSource.Businesses);
        }
    }

}
