using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows_App.Model;

namespace Windows_App.ViewModel
{
    class EstablishementViewModel
    {
       
        public ObservableCollection<Establishment> Establishments { get; set; }
        public EstablishementViewModel()
        {
           Establishments = new ObservableCollection<Establishment>(DummyDataSource.Establishments);
        }
    }
}
