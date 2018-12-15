using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows_App.Model;

namespace Windows_App.ViewModel
{
    class PromotionsViewModel
    {
        public ObservableCollection<Promotion> Promotions { get; set; }
        public PromotionsViewModel()
        {
            Promotions = new ObservableCollection<Promotion>(DummyDataSource.Promotions);
        }

    }
}
